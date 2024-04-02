using MagicVillaAPI.Mappers;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Services
{
    public class MagicVillaService
    {
        private readonly MagicVillaRepository _magicVillaRepository;
        public MagicVillaService(MagicVillaRepository magicVillaRepository)
        {
            _magicVillaRepository = magicVillaRepository;
        }

        public async Task<List<VillaDTO>> GetVillas()
        {
            var villas = await _magicVillaRepository.GetVillas().ConfigureAwait(false);
            if (villas == null)
            {
                return null;
            }
            var model = villas.Select(villa => VillaMapper.ConvertToVillaDto(villa)).ToList(); ;
            return model;
        }
        public async Task<VillaDTO> GetVilla(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var villa = await _magicVillaRepository.GetVilla(id).ConfigureAwait(false);
            if (villa == null)
            {
                return new VillaDTO();
            }
            var model = VillaMapper.ConvertToVillaDto(villa);
            return model;
        }
        public async Task<VillaDTO> CreateVilla([FromBody] VillaDTO villaDto)
        {
            var checkVilla = await _magicVillaRepository.checkVilla(villaDto).ConfigureAwait(false);
            if (checkVilla != null)
            {
                return null;
            }
            var insertModel = VillaMapper.ConvertToVilla(villaDto);
            var newId = Guid.NewGuid();
            insertModel.Id = newId;
            insertModel.CreatedDateTime = DateTime.Now.ToString();
            insertModel.UpdatedDateTime = DateTime.Now.ToString();           
            await _magicVillaRepository.Create(insertModel).ConfigureAwait(false);
            return await GetVilla(newId.ToString()).ConfigureAwait(false);
        }
        public async Task<VillaDTO> DeleteVilla(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var villa = await _magicVillaRepository.Delete(id).ConfigureAwait(false);
            VillaDTO model = null;
            if (villa != null)
            {
                model = VillaMapper.ConvertToVillaDto(villa);
            }
            return model;
        }
        public async Task<VillaDTO> UpdateVilla(string id, [FromBody] VillaDTO villaDto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var villa = await _magicVillaRepository.GetVilla(id).ConfigureAwait(false);
            if (villa == null)
            {
                return null;
            }
            var updatedModel = VillaMapper.ConvertToVilla(villaDto);
            updatedModel.UpdatedDateTime = DateTime.Now.ToString();
            updatedModel.CreatedDateTime = villa.CreatedDateTime;
            updatedModel.Id = villa.Id;
            await _magicVillaRepository.Update(id, updatedModel).ConfigureAwait(false);
            return villaDto;
        }
        public async Task<VillaDTO> UpdatePartialVilla(string id, [FromBody] JsonPatchDocument<VillaDTO> patchVillaDto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            var villa = await _magicVillaRepository.GetVilla(id).ConfigureAwait(false);
            if (villa == null)
            {
                return null;
            }
            VillaDTO model = VillaMapper.ConvertToVillaDto(villa);
            patchVillaDto.ApplyTo(model);
            var updatedModel = VillaMapper.ConvertToVilla(model); ;
            updatedModel.UpdatedDateTime = DateTime.Now.ToString();
            updatedModel.Id = villa.Id;
            await _magicVillaRepository.Update(id, updatedModel).ConfigureAwait(false);
            return model;
        }
    }
}
