
// DataBase Declaration

dotnet ef migrations add "ThirdMigration" -s .\Inf03.Solver.Inf03Api.csproj -p ..\Inf03.Solver.DataAccess\Inf03.Solver.DataAccess.csproj
dotnet ef database update


// DATABASE Initialization

To initialize dataBase data, at first We need to turn on ExamTitleQuestionContainerTest then after the operation is carried out,
We need to make sure if the rows in the database are fulfilled with appropriate data. When the title column and id column is fulfilled
We can turn on the ExamTitleQuestionContainerTest to complete the data in the exam table.
