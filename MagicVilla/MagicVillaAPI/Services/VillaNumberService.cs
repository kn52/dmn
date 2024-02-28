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
            var checkVilla = await _villaNumberRepository.checkVillaNumber(villaDto).ConfigureAwait(false);
            if (checkVilla != null)
            {
                return null;
            }
            var insertModel = _mapper.Map<VillaNumber>(villaDto);
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
            var updatedModel = _mapper.Map<VillaNumber>(villaDto);
            await _villaNumberRepository.Update(id, updatedModel).ConfigureAwait(false);
            return villaDto;
        }
        public async Task<VillaNumberDTO> UpdatePartialVillaNumber(int id, [FromBody] JsonPatchDocument<VillaNumberDTO> patchVillaDto)
        {
            var villa = await _villaNumberRepository.GetVillaNumberId(id).ConfigureAwait(false);
            if (villa == null)
            {
                return null;
            }
            VillaNumberDTO model = _mapper.Map<VillaNumberDTO>(villa);
            patchVillaDto.ApplyTo(model);
            var updatedModel = _mapper.Map<VillaNumber>(model); ;
            await _villaNumberRepository.Update(id, updatedModel).ConfigureAwait(false);
            return model;
        }
    }
}
