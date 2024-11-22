using StudentProject.Model;

namespace StudentProject.Interface
{
    public interface IPateints
    {
        List<PateintsModel> GetPateintsList();
        void AddPateint(PateintsModel model);

        PateintsModel Getpateint(int id);

        void UpdatePateint(PateintsModel model);

        void DeletePateint(int id);


    }
}
