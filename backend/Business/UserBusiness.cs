using App_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App_Api.Database;
using System.Linq;

namespace App_Api.Business
{
    public class UserBusiness
    {
        private readonly DBContext _context;

        public UserBusiness(DBContext pContext)
        {
            _context = pContext;
        }

        public async Task<Response<List<User>>> GetAll()
        {
            try
            {

                var lUsers = await _context.Users
                                           .Include(u => u.Address)
                                           .OrderBy(u => u.Id).ToListAsync();

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
        public async Task<Response<User>> Update(User pUser)
        {
            try
            {

                _context.Update(pUser);
                await _context.SaveChangesAsync();

                return new Response<User>()
                {
                    Message = BaseMessages.SuccessUpdate,
                    Status = ResultStatus.Success,
                    Result = pUser
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

        public async Task<Response<User>> Create(User pUser)
        {
            try
            {
                _context.Add(pUser);
                await _context.SaveChangesAsync();

                return new Response<User>()
                {
                    Message = BaseMessages.SuccessInsert,
                    Status = ResultStatus.Success,
                    Result = pUser
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


        public async Task<Response<User>> GetById(int pId)
        {
            try
            {
                var lUser = await _context.Users
                                         .AsNoTracking()
                                         .Include(u => u.Address)
                                         .FirstOrDefaultAsync(x => x.Id == pId);

                if (lUser != null)
                    return new Response<User>()
                    {
                        Message = BaseMessages.SuccessGet,
                        Status = ResultStatus.Success,
                        Result = lUser
                    };
                else
                    return new Response<User>()
                    {
                        Message = BaseMessages.NotFoundGet,
                        Status = ResultStatus.Error,
                        Result = null
                    };

            }
            catch (Exception)
            {
                return new Response<User>()
                {
                    Message = BaseMessages.ErrorGet,
                    Status = ResultStatus.Error,
                    Result = null
                };
            }
        }

    }
}
