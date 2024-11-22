using Code_First_Approach.Data.Entities;

namespace Code_First_Approach.Interfaces
{
    public interface Iinstructor
    {
        List<Instructors> instructorsList();

        void AddInstructors(Instructors instructors);
    }
}
