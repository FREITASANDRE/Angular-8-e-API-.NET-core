using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_Api.Models
{
    public class UserBusiness
    {
        private readonly AppContext _context;

        public UserBusiness(AppContext pContext)
        {
            _context = pContext;
        }

        public async Task<Response<List<User>>> GetAll()
        {
            try
            {

                var lUsers = await _context.Users.ToListAsync();

                if (lUsers != null)
                {
                    return new Response<List<User>>()
                    {
                        Message = BaseMessages.SuccessGet,
                        Status = ResultStatus.Success,
                        Result = lUsers
                    };
                }

                return new Response<List<User>>()
                {
                    Message = BaseMessages.NotFoundGet,
                    Status = ResultStatus.Success,
                    Result = null
                };
            }
            catch (Exception lEx)
            {
                return new Response<List<User>>()
                {
                    Message = lEx.Message,
                    Status = ResultStatus.Error,
                    Result = null
                };
            }
        }


        public async Task<Response<User>> Login(string pMail, string pPassword)
        {
            try
            {

                var lUser = await _context
                                    .Users
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Mail == pMail 
                                                                && x.Password == pPassword
                                                                && x.Status == "A");

                if (lUser != null)
                {
                    return new Response<User>()
                    {
                        Message = BaseMessages.UserFound,
                        Status = ResultStatus.Success,
                        Result = lUser
                    };
                }

                return new Response<User>()
                {
                    Message = BaseMessages.UserNotFound,
                    Status = ResultStatus.Error,
                    Result = null
                };
            }
            catch (Exception lEx)
            {
                return new Response<User>()
                {
                    Message = lEx.Message,
                    Status = ResultStatus.Error,
                    Result = null
                };
            }
        }

    }
}
