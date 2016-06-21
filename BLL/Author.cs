///
//?????,?????CodeSmith??
//???:??
//????:2010?1?24?
///

using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

using Blog.Model;
using Blog.DBUtility;
using Blog.IDAL;

using Blog.SqlServerDAL;
using Blog.AccessDAL;
using Blog.DALFactory;



namespace Blog.BLL
{
    ///
    //Author
    ///
    public static class AuthorManager
    {
        private static Blog.IDAL.IAuthor dal = Blog.DALFactory.DataAccess.CreateAuthor();

        public static AuthorEntity SelectAuthorByID(int t_author_id)
        {
            AuthorEntity temp = null;
            try
            {
                temp = dal.SelectauthorByID(t_author_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return temp;
        }

        public static IList<AuthorEntity> GetAllAuthor()
        {
            IList<AuthorEntity> temp = null;
            try
            {
                temp = dal.GetAllauthor();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return temp;
        }

        public static AuthorEntity GetAuthorByName(string username)
        {
            IList<AuthorEntity> temp = null;
            AuthorEntity entity = new AuthorEntity();

            try
            {
                temp = dal.GetAllauthor();
                foreach (AuthorEntity t in temp)
                {
                    if (t.Username.Equals(username))
                    {
                        return t;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }


        public static IList<AuthorEntity> GetAllAuthorByrole_id(int t_role_id)
        {
            IList<AuthorEntity> temp = null;
            try
            {
                temp = dal.GetAllauthorByrole_id(t_role_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return temp;
        }

        public static int Insertauthor(AuthorEntity t_Author)
        {
            int i = -1;
            try
            {
                i = dal.Insertauthor(t_Author);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }

        public static int UpdateAuthor(AuthorEntity t_Author)
        {
            int i = -1;
            try
            {
                i = dal.Updateauthor(t_Author);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }

        public static int Deleteauthor(int t_author_id)
        {
            int i = -1;
            try
            {
                i = dal.Deleteauthor(t_author_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return i;
        }
    }
}


