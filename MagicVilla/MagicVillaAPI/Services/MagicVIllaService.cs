using AutoMapper;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVillaAPI.Services
{
    public class MagicVillaService
    {
        private IMapper _mapper;
        private readonly MagicVillaRepository _magicVillaRepository;
        public MagicVillaService(IMapper mapper, MagicVillaRepository magicVillaRepository)
        {
            _mapper = mapper;
            _magicVillaRepository = magicVillaRepository;
        }

        public async Task<List<VillaDTO>> GetVillas()
        {
            var villas = await _magicVillaRepository.GetVillas().ConfigureAwait(false);
            if (villas == null)
            {
                return null;
            }
            var model = _mapper.Map<List<VillaDTO>>(villas);
            return model;
        }
        public async Task<VillaDTO> GetVilla(string id)
        {
            var villa = await _magicVillaRepository.GetVilla(id).ConfigureAwait(false);
            if (villa == null)
            {
                return new VillaDTO();
            }
            var model = _mapper.Map<VillaDTO>(villa);
            return model;
        }
        public async Task<VillaDTO> CreateVilla([FromBody] VillaDTO villaDto)
        {
            var checkVilla = await _magicVillaRepository.checkVilla(villaDto).ConfigureAwait(false);
            if (checkVilla != null)
            {
                return null;
            }
            var insertModel = _mapper.Map<Villa>(villaDto);
            var newId = Guid.NewGuid();
            insertModel.Id = newId;
            insertModel.CreatedDateTime = DateTime.Now.ToString();
            insertModel.UpdatedDateTime = DateTime.Now.ToString();           
            await _magicVillaRepository.Create(insertModel).ConfigureAwait(false);
            return await GetVilla(newId.ToString()).ConfigureAwait(false);
        }
        public async Task<VillaDTO> DeleteVilla(string id)
        {
            var villa = await _magicVillaRepository.Remove(id).ConfigureAwait(false);
            VillaDTO model = null;
            if (villa != null)
            {
                _mapper.Map<VillaDTO>(villa);
            }
            return model;
        }
        public async Task<VillaDTO> UpdateVilla(string id, [FromBody] VillaDTO villaDto)
        {
            var updatedModel = _mapper.Map<Villa>(villaDto); ;
            updatedModel.UpdatedDateTime = DateTime.Now.ToString();
            await _magicVillaRepository.Update(id, updatedModel).ConfigureAwait(false);
            return villaDto;
        }
        public async Task<VillaDTO> UpdatePartialVilla(string id, [FromBody] JsonPatchDocument<VillaDTO> patchVillaDto)
        {
            var villa = await _magicVillaRepository.GetVilla(id).ConfigureAwait(false);
            if (villa == null)
            {
                return null;
            }
            VillaDTO model = _mapper.Map<VillaDTO>(villa);
            patchVillaDto.ApplyTo(model);
            var updatedModel = _mapper.Map<Villa>(model); ;
            updatedModel.UpdatedDateTime = DateTime.Now.ToString();
            await _magicVillaRepository.Update(id, updatedModel).ConfigureAwait(false);
            return model;
        }
    }
}
