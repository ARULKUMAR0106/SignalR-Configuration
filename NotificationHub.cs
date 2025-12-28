  private readonly IHubContext<TaskNotificationHub,ITaskNotificationHub> _hub;
  private readonly userID;
  public class NotificationHub{
   public NotificationHub( ITaskNotificationHub> task)
   {
      userID=GetCurrentLoggedInUser();
       _hub = task;

   }
  public async  Task Status(string TaskID){
        


                    System.Threading.Tasks.Task SpTask = System.Threading.Tasks.Task.Run(async () =>
                    {   //do some work
                        await _hub.Clients.User(userID.ToString())
                                      .JobStatus("JobCompleted", TaskID);
                    });

                    System.Threading.Tasks.Task progressTask = System.Threading.Tasks.Task.Run(async () =>
                    {
                        if (!string.IsNullOrEmpty(ID))
                        {
                            await _hub.Clients.User(userID.ToString())
                                   .Progress("ProgressUpdate", "1 |"+TaskID);
                            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(5));
                            while (!SpTask.IsCompleted)
                            {

                                string query = "select Progress from " + Metadata.tableName + " where Id= " + ID;

                                var progress = await _dataSqlRaws.dataretrival(query);

                                await _hub.Clients.User(userID.ToString())
                                    .JobProgress("ProgressUpdate", progress.StringID+" |"+TaskID);

                                await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(3)); // non-blocking
                            }
                        }
                    });

   }

}

  
