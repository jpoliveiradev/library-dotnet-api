using Library.API.Models;

namespace Library.API.Services.Interfaces {
    public interface IAdminService {

        Admins AdminCreate(Admins model); 
        Admins AdminUpdate(Admins model);       

    }
}
