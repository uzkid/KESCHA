System.Console.Write("Hello, Please Enter your Name: ");
string Name  = Console.ReadLine();
System.Console.WriteLine($"Welcome, {Name}");

int KESCHAsAge = 1;
System.Console.Write("Now, Enter Your Age Please: ");
string UsersAgeAsString = Console.ReadLine();
System.Console.WriteLine("Converting...");
int UAAint = Convert.ToInt32(UsersAgeAsString);
System.Console.WriteLine($"Succesfully Converted! {UsersAgeAsString}");
int AgeDifference = UAAint - KESCHAsAge;

System.Console.WriteLine($"The Difference Between Your and KESCHAs Ages is {AgeDifference}");