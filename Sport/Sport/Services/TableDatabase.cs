using Sport.Models;
using SQLite;
using System;

namespace Sport.Services
{
    public class TableDatabase
    {
        public BodyPartsDatabase GetBodyPartsDatabase { get; set; }
        public ExerciseDatabase GetExerciseDatabase { get; set; }
        public WorkoutDatabase GetWorkoutDatabase { get; set; }
        public TrainingDayDatabase GetTrainingDayDatabase { get; set; }

        public UserDatabase GetUserDatabase { get; set; }
        public TableDatabase(string dbPath)
        {
            App._database = new SQLiteAsyncConnection(dbPath);
            App._database.CreateTableAsync<Exercise>().Wait();
            App._database.CreateTableAsync<BodyParts>().Wait();
            App._database.CreateTableAsync<Workout>().Wait();
            App._database.CreateTableAsync<TrainingDay>().Wait();
            App._database.CreateTableAsync<User>().Wait();
            GetBodyPartsDatabase = new BodyPartsDatabase();
            GetExerciseDatabase = new ExerciseDatabase();
            GetWorkoutDatabase = new WorkoutDatabase();
            GetTrainingDayDatabase = new TrainingDayDatabase();
            GetUserDatabase = new UserDatabase(dbPath);
            AddElementDatabase();
        }

        public async void AddElementDatabase()
        {
            await GetBodyPartsDatabase.AddBodyPartsDatabase();
            await GetExerciseDatabase.AddExercise();
            await GetWorkoutDatabase.AddWorkout();
            await GetTrainingDayDatabase.AddTrainingDay();
        }
    }
}
