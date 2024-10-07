using MaxFitGym.Models;

namespace MaxFitGym.IRepository
{
    public interface IProgramRepository
    {
        ProgramDTO AddProgram(ProgramDTO programDto);
        ICollection<ProgramDTO> GetAllPrograms();
        ProgramDTO GetProgramById(int ProgramId);

        void UpdateProgram(int ProgramID, int TotalFee);
        void DeleteProgram(int CourseId);
    }
}
