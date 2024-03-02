using MagicVillaAPI.Mappers;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Services
{
    public class VillaNumberService
    {
        private readonly VillaNumberRepository _villaNumberRepository;
        private readonly MagicVillaRepository _magicVillaRepository;

        public VillaNumberService(VillaNumberRepository villaNumberRepository, MagicVillaRepository magicVillaRepository)
        {
            _villaNumberRepository = villaNumberRepository;
            _magicVillaRepository = magicVillaRepository;
        }
        public async Task<List<VillaNumberDTO>> GetVillaNumbers()
        {
            var villas = await _villaNumberRepository.GetAll().ConfigureAwait(false);
            if (villas == null)
            {
                return null;
            }
            var model = villas.Select(villa => VillaNumberMapper.ConvertToVillaNumberDto(villa)).ToList();
            return model;
        }
        public async Task<VillaNumberDTO> GetVillaNumber(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var villa = await _villaNumberRepository.GetById(id).ConfigureAwait(false);
            if (villa == null)
            {
                return new VillaNumberDTO();
            }
            var model = VillaNumberMapper.ConvertToVillaNumberDto(villa);
            return model;
        }
        public async Task<VillaNumberDTO> CreateVillaNumber([FromBody] VillaNumberDTO villaDto)
        {
            if (string.IsNullOrEmpty(villaDto.VillaNo) || string.IsNullOrEmpty(villaDto.VillaId))
            {
                return null;
            }
            var checkVillaNumber = await _villaNumberRepository.GetVillaNumberId(Convert.ToInt32(villaDto.VillaNo)).ConfigureAwait(false);
            var checkVilla = await _magicVillaRepository.GetVilla(villaDto.VillaId).ConfigureAwait(false);
            if (checkVillaNumber != null || checkVilla == null)
            {
                return null;
            }
            var insertModel = VillaNumberMapper.ConvertToVillaNumber(villaDto);
            var newId = Guid.NewGuid();
            insertModel.Id = newId;
            insertModel.CreatedDateTime = DateTime.Now.ToString();
            insertModel.UpdatedDateTime = DateTime.Now.ToString();
            villaDto.Id = newId.ToString();
            villaDto.Villa = checkVilla;
            await _villaNumberRepository.Create(insertModel).ConfigureAwait(false);
            return villaDto;
        }
        public async Task<VillaNumberDTO> DeleteVillaNumber(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var villa = await _villaNumberRepository.Delete(id).ConfigureAwait(false);
            VillaNumberDTO model = null;
            if (villa != null)
            {
                model = VillaNumberMapper.ConvertToVillaNumberDto(villa);
            }
            return model;
        }
        public async Task<VillaNumberDTO> UpdateVillaNumber(string id, [FromBody] VillaNumberDTO villaDto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var villaNumber = await _villaNumberRepository.GetById(id).ConfigureAwait(false);
            if (villaNumber == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(villaDto.VillaId))
            {
                villaDto.VillaId = villaNumber.VillaId.ToString();
            }
            var updatedModel = VillaNumberMapper.ConvertToVillaNumber(villaDto);
            updatedModel.UpdatedDateTime = DateTime.Now.ToString();
            updatedModel.CreatedDateTime = villaNumber.CreatedDateTime;
            updatedModel.Id = villaNumber.Id;
            await _villaNumberRepository.Update(id, updatedModel).ConfigureAwait(false);
            return villaDto;
        }
        public async Task<VillaNumberDTO> UpdatePartialVillaNumber(string id, [FromBody] JsonPatchDocument<VillaNumberDTO> patchVillaDto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var villaNumber = await _villaNumberRepository.GetById(id).ConfigureAwait(false);
            if (villaNumber == null)
            {
                return null;
            }
            VillaNumberDTO model = VillaNumberMapper.ConvertToVillaNumberDto(villaNumber);
            patchVillaDto.ApplyTo(model);
            var updatedModel = VillaNumberMapper.ConvertToVillaNumber(model);
            updatedModel.VillaId = villaNumber.VillaId;
            updatedModel.UpdatedDateTime = DateTime.Now.ToString();
            updatedModel.Id = villaNumber.Id;
            await _villaNumberRepository.Update(id, updatedModel).ConfigureAwait(false);
            return model;
        }
    }
}
