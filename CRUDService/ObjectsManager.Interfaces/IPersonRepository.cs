using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsManager.Model;

namespace ObjectsManager.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetAll();
        int Add(Person person);
        Person Get(int id);
        Person Update(Person person);
        bool Delete(int id);
    }
}
