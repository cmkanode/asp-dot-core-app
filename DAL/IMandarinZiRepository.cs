using System.Collections.Generic;
using cmkService.Models;

namespace cmkService.DAL
{
    public interface IMandarinZiRepository
    {
        //IEnumerable<MandarinZi> GetAll();
        MandarinZi Find(int id);
        IEnumerable<MandarinZi> FindByDefinition(string searchterm);
        IEnumerable<MandarinZi> FindByCharacter(string searchterm);
        IEnumerable<MandarinZi> FindByRadical(string searchterm);
        IEnumerable<MandarinZi> FindByStroke(int strokeCount);
    }
}