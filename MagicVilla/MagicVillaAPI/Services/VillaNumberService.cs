using AutoMapper;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Services
{
    public class VillaNumberService
    {
        private IMapper _mapper;
        private readonly VillaNumberRepository _villaNumberRepository;
        private readonly MagicVillaRepository _magicVillaRepository;

        public VillaNumberService(IMapper mapper, VillaNumberRepository villaNumberRepository)
        {
            _mapper = mapper;
            _villaNumberRepository = villaNumberRepository;
        }
        public async Task<List<VillaNumberDTO>> GetVillaNumbers()
        {
            var villas = await _villaNumberRepository.GetAll().ConfigureAwait(false);
            if (villas == null)
            {
                return null;
            }
            var model = _mapper.Map<List<VillaNumberDTO>>(villas);
            return model;
        }
        public async Task<VillaNumberDTO> GetVillaNumber(string id)
        {
            var villa = await _villaNumberRepository.GetById(id).ConfigureAwait(false);
            if (villa == null)
            {
                return new VillaNumberDTO();
            }
            var model = _mapper.Map<VillaNumberDTO>(villa);
            return model;
        }
        public async Task<VillaNumberDTO> CreateVillaNumber([FromBody] VillaNumberDTO villaDto)
        {
            var checkVillaNumber = await _villaNumberRepository.checkVillaNumber(villaDto).ConfigureAwait(false);
            var checkVilla = await _magicVillaRepository.GetVilla(villaDto.Id).ConfigureAwait(false);
            if (checkVillaNumber != null || checkVilla == null)
            {
                return null;
            }
            var insertModel = _mapper.Map<VillaNumber>(villaDto);
            var newId = Guid.NewGuid();
            insertModel.Id = newId;
            insertModel.CreatedDateTime = DateTime.Now.ToString();
            insertModel.UpdatedDateTime = DateTime.Now.ToString();
            villaDto.Id = newId.ToString();
            await _villaNumberRepository.Create(insertModel).ConfigureAwait(false);
            return villaDto;
        }
        public async Task<VillaNumberDTO> DeleteVillaNumber(int id)
        {
            var villa = await _villaNumberRepository.Delete(id).ConfigureAwait(false);
            VillaNumberDTO model = null;
            if (villa != null)
            {
                _mapper.Map<VillaNumberDTO>(villa);
            }
            return model;
        }
        public async Task<VillaNumberDTO> UpdateVillaNumber(int id, [FromBody] VillaNumberDTO villaDto)
        {
            var villaNumber = await _villaNumberRepository.GetVillaNumberId(id).ConfigureAwait(false);
            if (villaNumber == null)
            {
                return null;
            }
            villaDto.VillaId = villaNumber.VillaId;
            villaDto.UpdatedDateTime = DateTime.Now.ToString();
            var updatedModel = _mapper.Map<VillaNumber>(villaDto);
            await _villaNumberRepository.Update(id, updatedModel).ConfigureAwait(false);
            return villaDto;
        }
        public async Task<VillaNumberDTO> UpdatePartialVillaNumber(int id, [FromBody] JsonPatchDocument<VillaNumberDTO> patchVillaDto)
        {
            var villaNumber = await _villaNumberRepository.GetVillaNumberId(id).ConfigureAwait(false);
            if (villaNumber == null)
            {
                return null;
            }
            VillaNumberDTO model = _mapper.Map<VillaNumberDTO>(villaNumber);
            patchVillaDto.ApplyTo(model);
            var updatedModel = _mapper.Map<VillaNumber>(model);
            updatedModel.VillaId = villaNumber.VillaId;
            updatedModel.UpdatedDateTime = DateTime.Now.ToString();
            await _villaNumberRepository.Update(id, updatedModel).ConfigureAwait(false);
            return model;
        }
    }
}
