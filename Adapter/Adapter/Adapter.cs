using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.Models.Interfaces;
using Example_04.Homework.SecondOrmLibrary;

namespace Adapter
{
    public class Adapter<TDbEntity> : IFirstOrm<TDbEntity> where TDbEntity : IDbEntity
    {
        private ISecondOrm secondOrm;

        public Adapter(ISecondOrm secondOrm)
        {
            this.secondOrm = secondOrm;
        }

        public void Create(TDbEntity entity)
        {
            if (entity is DbUserEntity)
            {
                secondOrm.Context.Users.Add(entity as DbUserEntity);
            }
            else if (entity is DbUserInfoEntity)
            {
                secondOrm.Context.UserInfos.Add(entity as DbUserInfoEntity);
            }
            else throw new ArgumentException();
        }

        public TDbEntity Read(int id)
        {
            return (TDbEntity)secondOrm.Context.Users.Concat<IDbEntity>(secondOrm.Context.UserInfos)
                .FirstOrDefault(e => e.Id == id);
        }

        public void Update(TDbEntity entity)
        {
            Delete(entity);
            Create(entity);
        }

        public void Delete(TDbEntity entity)
        {
            if (entity is DbUserEntity)
            {
                secondOrm.Context.Users.Remove(entity as DbUserEntity);
            }
            else if (entity is DbUserInfoEntity)
            {
                secondOrm.Context.UserInfos.Remove(entity as DbUserInfoEntity);
            }
            else throw new ArgumentException();
        }
    }
}
