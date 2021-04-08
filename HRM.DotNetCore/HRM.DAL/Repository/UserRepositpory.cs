using AutoMapper;
using HRM.DAL.Database;
using HRM.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Repository
{
    public class UserRepositpory : IUserRepositpory
    {
        private readonly Databasecontext _dataConext;
        public UserRepositpory()
        {
            _dataConext = new Databasecontext();
        }
      
        public UserLoignViewModel login(UserLoignViewModel obj)
        {
            var ent = _dataConext.UserRegs.FirstOrDefault(x => x.email == obj.email && x.password == obj.password);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserReg, UserLoignViewModel>());
            var mapper = new Mapper(config);
            UserLoignViewModel user = mapper.Map<UserLoignViewModel>(ent);
            if(user == null)
            {
                return null;
            }
            return user;

        }

    }
}
