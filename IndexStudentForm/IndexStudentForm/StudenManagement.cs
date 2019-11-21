using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexStudentForm
{
   public class StudenManagement
    {
            public PM20577[] GetStudent()
            {
                var db = new OOPCSEntities();
                return db.PM20577.ToArray();
            }

            public void CreateStudent(string code, string name, bool gender, string hometown)
            {
                var newClass = new PM20577();
                newClass.code = code;
                newClass.name = name;
                newClass.gender = gender;
                newClass.hometown = hometown;

                var db = new OOPCSEntities();
                db.PM20577.Add(newClass);
                db.SaveChanges();
            }

            public void UpdateStudent(int id, string code, string name ,  bool gender , string hometown)
            {
                var db = new OOPCSEntities();
                var oldClass = db.PM20577.Find(id);

                oldClass.code = code;
                oldClass.name = name;
                oldClass.gender = gender;
                oldClass.hometown = hometown;
                db.Entry(oldClass).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            public void DeleteStudent(int id)
            {
                var db = new OOPCSEntities();
                var @class = db.PM20577.Find(id);
                db.PM20577.Remove(@class);
                db.SaveChanges();
            }

            public PM20577 GetStudent(int id)
            {
                var db = new OOPCSEntities();
                return db.PM20577.Find(id);
            }
    }
    }

