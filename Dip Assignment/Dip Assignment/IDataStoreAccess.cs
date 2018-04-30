using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dip_Assignment
{
    interface IDataStoreAccess
    {
        String SaveFace(String username, Byte[] faceBlob);
        List<Face> CallFaces(String username);
        bool IsUsernameValid(String username);
        String SaveAdmin(String username, String password);
        void DeleteUser(String username);
        int GetUserId(String username);
        int GenerateUserId();
        String GetUsername(int userId);
        List<String> GetAllUsernames();
        int CheckWithCourse(string username);
        int CheckIfAlreadyExists(string username);
        string MarkAttendance(string username);
    }
}
