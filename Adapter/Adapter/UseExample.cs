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
    class UseExample
    {
        public static void Main(string[] args)
        {
            ISecondOrm second = null;
            IFirstOrm<IDbEntity> first = new Adapter<IDbEntity>(second);

            var entityUser = new DbUserEntity();
            var entityUserInfo = new DbUserInfoEntity();

            first.Create(entityUser);
            first.Create(entityUserInfo);
        }
    }
}
