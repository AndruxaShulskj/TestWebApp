using AutoMapper;
using TestWebApp.Business.Interfaces;
using TestWebApp.Business.Models;
using TestWebApp.Common;
using TestWebApp.DataAccess.Entities;
using TestWebApp.DataAccess.Interfaces;

namespace TestWebApp.Business.Services
{
    public class UserDataService: IUserDataService
    {
        private readonly IUserDataRepository _userDataRepository;
        private readonly IMapper _mapper;

        public UserDataService(IUserDataRepository userDataRepository, IMapper mapper)
        {
            _userDataRepository = userDataRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserData> GetAll(DataFilter? filter)
        {
            return _userDataRepository.GetAll(filter).Select(k=>_mapper.Map<UserData>(k));
        }

        public UserData Get(int id)
        {
            return _mapper.Map<UserData>(_userDataRepository.Get(id));
        }

        public UserData Create(UserData data)
        {
            var userEntity = _mapper.Map<UserDataEntity>(data);
            _userDataRepository.Create(userEntity);

            return data;
        }

        public UserData Edit(UserData data)
        {
            var userEntity = _mapper.Map<UserDataEntity>(data);
            _userDataRepository.Update(userEntity);

            return data;
        }

        public void Delete(int id)
        {
            _userDataRepository.Delete(id);
        }

        public Task DeleteAll()
        {
            return _userDataRepository.DeleteAll();
        } 

        public async Task CreateAsync(IEnumerable<UserData> list)
        {
            await _userDataRepository.DeleteAll();
            var listEntities = list.Select(k => _mapper.Map<UserDataEntity>(k));

            foreach (var entity in listEntities)
            {
                _userDataRepository.Create(entity);
            }

            await _userDataRepository.SaveAsync();
        }
    }
}
