using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM06
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
    class Theatre
    {
        public string TheatreName { get; set; }
    }


    class Movie
    {   
        public string MovieName { get; set; }
        public string ThName { get; set; }
    }

    class Show
    {
        public string MName { get; set; }
        public string TName { get; set; }
        public string ShowName { get; set; }

    }

    class Booking
    {
        public string Moviename { get; set; }
        public string Thrname { get; set; }
        public string ShName { get; set; }
        public int No_of_tickets { get; set; }
        public double Cost { get; set; }
    }

    class MovieTicketing
    {
        public List<User> UserInformation { get; set; }
        public List<Theatre> Theatres { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Show> Shows { get; set; }
        public List<Booking> Bookings { get; set; }

        public MovieTicketing()
        {
            User U1 = new User();
            U1.Username = "Admin";
            U1.UserType = "Admin";
            U1.Password = "Admin";
            UserInformation = new List<User>();
            UserInformation.Add(U1);
            Theatres = new List<Theatre>();
            Movies = new List<Movie>();
            Shows = new List<Show>();
            Bookings = new List<Booking>();
        }

        public void AddThreate()
        {
            Theatre T1 = new Theatre();
            Console.WriteLine("Enter Theatre Name: ");
            T1.TheatreName = Console.ReadLine();
            if (T1.TheatreName != "")
            {
                Theatres.Add(T1);
                Console.WriteLine("Theatre named: "+ T1.TheatreName + " added.");  
            }
            else
                Console.WriteLine("Theatre name cannot be null.");    
        }

        public bool AddMovie()
        {
            Movie M1 = new Movie();
            Console.WriteLine("Enter Theatre Name: ");
            M1.ThName = Console.ReadLine();
            if (M1.ThName != "")
            {
                foreach (Theatre th in Theatres)
                {
                    if (th.TheatreName == M1.ThName)
                    {
                        Console.WriteLine("Enter Movie Name: ");
                        M1.MovieName = Console.ReadLine();
                        Movies.Add(M1);
                        Console.WriteLine(M1.MovieName + " added to " + M1.ThName);
                        return true;
                    }
                }
                Console.WriteLine("Theatre not found.");
                return false;
            }
            else
            {
                Console.WriteLine("Theatre name cannot be null.");
                return false;
            }
        }

        public bool AddShow()
        {
            Show S1 = new Show();
            Console.WriteLine("Enter Theatre Name: ");
            S1.TName = Console.ReadLine();
            Console.WriteLine("Enter Movie Name: ");
            S1.MName = Console.ReadLine();
            if(S1.MName != "" && S1.TName!="")
            {
                foreach(Movie m in Movies)
                {
                    if(m.ThName==S1.TName && m.MovieName == S1.MName)
                    {
                        Console.WriteLine("Enter the Show Timing: ");
                        S1.ShowName = Console.ReadLine();
                        Shows.Add(S1);
                        Console.WriteLine(S1.ShowName + " show of " + S1.MName+" at "+ S1.TName+ " Theatre added.");
                        return true;
                    }
                }
                Console.WriteLine(S1.MName+ " Movie is not in "+ S1.TName+" Theatre.");
                return false;
            }
            else
            {
                Console.WriteLine("Theatre or Movie name cannot be null.");
                return false;
            }
        }

        public bool UpdateThreatre()
        {
            Theatre T2 = new Theatre();
            Console.WriteLine("Enter the name of Theatre to be updated: ");
            T2.TheatreName = Console.ReadLine();
            int[] indx = Enumerable.Repeat(-1, Theatres.Count).ToArray();
            int i = 0;
            if (T2.TheatreName != "")
            {
                foreach (Theatre t in Theatres)
                {
                    if (t.TheatreName == T2.TheatreName)
                    {
                        indx[i] = Theatres.IndexOf(t);
                        i++;
                    }
                }
                if (i != 0)
                {
                    Console.WriteLine("Enter New Theatre Name: ");
                    T2.TheatreName = Console.ReadLine();
                    foreach (int j in indx)
                    {
                        if (j != -1)
                        {
                            Theatres.RemoveAt(j);
                            Theatres.Insert(j, T2);
                        } 
                    }
                    Console.WriteLine("Theatre name: " + T2.TheatreName + " updated.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Theatre not found.");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Theatre name cannot be null.");
                return false;
            }

            
        }

        public bool UpdateMovie()
        {
            Movie M2 = new Movie();
            Console.WriteLine("Enter Theatre Name: ");
            M2.ThName = Console.ReadLine();
            Console.WriteLine("Enter the name of Movie to be updated: ");
            M2.MovieName = Console.ReadLine();
            int[] indx = Enumerable.Repeat(-1, Movies.Count).ToArray();
            int i = 0;
            if (M2.ThName != "" && M2.MovieName != "")
            {
                foreach (Movie m in Movies)
                {
                    if (m.ThName == M2.ThName && m.MovieName == M2.MovieName)
                    {
                        
                        indx[i] = Movies.IndexOf(m);
                        i++;
                        
                    }
                }
                if (i != 0)
                {
                    Console.WriteLine("Enter New Theatre Name: ");
                    M2.MovieName = Console.ReadLine();
                    foreach (int j in indx)
                    {
                        if (j != -1)
                        {
                            Movies.RemoveAt(j);
                            Movies.Insert(j, M2);
                        }
                    }
                    Console.WriteLine("Movie name: " + M2.MovieName + " updated.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Movie or Theatre name incorrect.");
                    return false;
                }
                
            }
            else
            {
                Console.WriteLine("Movie or Theatre name cannot be null.");
                return false;
            }
        }

        public bool UpdateShow()
        {
            Show S2 = new Show();
            Console.WriteLine("Enter Theatre Name: ");
            S2.TName = Console.ReadLine();
            Console.WriteLine("Enter Movie Name: ");
            S2.MName = Console.ReadLine();
            if (S2.MName != "" && S2.TName != "")
            {
                foreach (Movie m in Movies)
                {
                    if (m.ThName == S2.TName && m.MovieName == S2.MName)
                    {
                        Console.WriteLine("Enter the Show Timing to be Updated: ");
                        S2.ShowName = Console.ReadLine();
                        foreach (Show s in Shows)
                        {
                            if (s.ShowName == S2.ShowName)
                            {
                                Console.WriteLine("Enter the New Show Timing: ");
                                S2.ShowName = Console.ReadLine();
                                int i = Shows.IndexOf(s);
                                Shows.RemoveAt(i);
                                Shows.Insert(i, S2);
                                Console.WriteLine("Show Timing: " + S2.ShowName + " updated for " + S2.MName + " at " + S2.TName + " Theatre.");
                                return true;
                            }

                        }
                        Console.WriteLine("Show Timing is incorrect.");
                        return false;
                    }
                }
                Console.WriteLine("Movie or Theatre name incorrect.");
                return false;
            }
            else
            {
                Console.WriteLine("Movie or Theatre name cannot be null.");
                return false;
            }
        }

        public bool DeleteShow()
        {
            Show S3 = new Show();
            Console.WriteLine("Enter Theatre Name: ");
            S3.TName = Console.ReadLine();
            Console.WriteLine("Enter Movie Name: ");
            S3.MName = Console.ReadLine();
            if (S3.MName != "" && S3.TName != "")
            {
                foreach (Movie m in Movies)
                {
                    if (m.ThName == S3.TName && m.MovieName == S3.MName)
                    {
                        foreach (Show s in Shows)
                        {
                            if (s.ShowName == S3.ShowName)
                            {
                                Console.WriteLine("Enter the Show Timing to be Deleted: ");
                                S3.ShowName = Console.ReadLine();
                                int i = Shows.IndexOf(s);
                                Shows.RemoveAt(i);
                                Console.WriteLine("Show Timing: " + S3.ShowName + " deleted for " + S3.MName + " at " + S3.TName + " Theatre.");
                                return true;
                            }

                        }
                        Console.WriteLine("Show Timing incorrect.");
                        return false;
                    }
                }
                Console.WriteLine("Movie or Theatre name incorrect.");
                return false;
            }
            else
            {
                Console.WriteLine("Movie or Theatre name cannot be null.");
                return false;
            }
        }

        public void DisplayTheatre()
        {
            Console.WriteLine("List of Theatres");
            foreach(Theatre th in Theatres)
            {
                Console.WriteLine(th.TheatreName);
            }
        } 

        public void DisplayMovie()
        {
            Console.WriteLine("List of Movies:");
            Console.WriteLine("Theatre\t\tMovie");
            foreach (Movie mo in Movies)
            {
                Console.WriteLine(mo.ThName + "\t\t" + mo.MovieName);
            }
        }

        public void DisplayShow()
        {
            Console.WriteLine("List of Shows:");
            Console.WriteLine("Theatre\t\tMovie\t\tShow");
            foreach(Show sh in Shows)
            {
                Console.WriteLine(sh.TName + "\t\t" + sh.MName +"\t\t"+ sh.ShowName);
            }
        }

        public bool BookTicket()
        {
            Booking B1 = new Booking();
            Console.WriteLine("Enter Theatre Name:");
            B1.Thrname = Console.ReadLine();
            Console.WriteLine("Enter Movie Name:");
            B1.Moviename = Console.ReadLine();
            Console.WriteLine("Enter Show Timing:");
            B1.ShName = Console.ReadLine();
            if(B1.Moviename != "" && B1.Thrname != ""&& B1.ShName!="")
            {
                foreach(Show s in Shows)
                {
                    if(s.MName==B1.Moviename && s.TName==B1.Thrname&& s.ShowName==B1.ShName)
                    {
                        Console.WriteLine("No of Tickets:");
                        B1.No_of_tickets = int.Parse(Console.ReadLine());
                        B1.Cost = B1.No_of_tickets * 185;
                        Bookings.Add(B1);
                        Console.WriteLine("Greetings! Tickets Booked.");
                        return true;
                    }
                }
                Console.WriteLine("Show Time OR Movie Name OR Theatre Name is INVALID.");
                return false;
            }
            else
            {
                Console.WriteLine("Show Time OR Movie Name OR Theatre Name cannot be Null.");
                return false;
            }

        }

        public void PrintTicket()
        {
            int i = Bookings.Count - 1;
            Console.WriteLine("Your Tickets Details:");
            Console.WriteLine("Theatre Name: {0}", Bookings[i].Thrname);
            Console.WriteLine("Movie Name: {0}", Bookings[i].Moviename);
            Console.WriteLine("Show Timing: {0}", Bookings[i].ShName);
            Console.WriteLine("No of Tickets: {0}", Bookings[i].No_of_tickets);
            Console.WriteLine("Total Price: {0}", Bookings[i].Cost);
            Console.WriteLine("Enjoy the Show!");
        }

        public void AddAgent()
        {
            User U2 = new User();
            Console.WriteLine("Enter UserName for Agent: ");
            U2.Username = Console.ReadLine();
            Console.WriteLine("Enter Password for Agent: ");
            U2.Password = Console.ReadLine();
            U2.UserType = "Agent";
            UserInformation.Add(U2);
        }

        public void AdminMenu()
        {
            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine("1. Add Theatre");
            Console.WriteLine("2. Update Theatre");
            Console.WriteLine("3. Add Movie");
            Console.WriteLine("4. Update Movie");
            Console.WriteLine("5. Add Show");
            Console.WriteLine("6. Update Show");
            Console.WriteLine("7. Delete Show");
            Console.WriteLine("8. Display Theatres");
            Console.WriteLine("9. Display Movies");
            Console.WriteLine("10. Display Shows");
            Console.WriteLine("11. Add Agent");
            Console.WriteLine("12. Book Ticket");
            Console.WriteLine("13. Print Ticket");
            Console.WriteLine("14. Exit");
            Console.WriteLine("---------------------------------------\n");       
        }

        public void AgentMenu()
        {
            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine("1. Views Shows");
            Console.WriteLine("2. New Ticket");
            Console.WriteLine("3. Print Ticket");
            Console.WriteLine("4. Exit");
            Console.WriteLine("---------------------------------------\n");
        }

        public int GetChoice()
        {
            Console.WriteLine("\nPlease enter your Choice");
            int i = Convert.ToInt16(Console.ReadLine());
            return i;
            
        }

        public string Login()
        {
            Console.WriteLine("Enter Username: ");
            string uname =  Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string pass = Console.ReadLine();
            foreach(User u in UserInformation)
            {
                if (uname == u.Username && pass == u.Password)
                {
                    return u.UserType;
                }
            }
            return null;
        }

    }

    class TM06_MovieTicketBooking
    {
        static void Main()
        {
            MovieTicketing MT = new MovieTicketing();
            do
            {
                Console.WriteLine("---------------------------------------\n");
                string log = MT.Login();
                int i;
                if (log == "Admin")
                {
                    do
                    {
                        MT.AdminMenu();
                        i = MT.GetChoice();
                        switch (i)
                        {
                            case 1:
                                MT.AddThreate();
                                break;
                            case 2: MT.UpdateThreatre();
                                break;
                            case 3: MT.AddMovie();
                                break;
                            case 4:MT.UpdateMovie();
                                break;
                            case 5: MT.AddShow();
                                break;
                            case 6: MT.UpdateShow();
                                break;
                            case 7: MT.DeleteShow();
                                break;
                            case 8:
                                MT.DisplayTheatre();
                                break;
                            case 9: MT.DisplayMovie();
                                break;
                            case 10: MT.DisplayShow();
                                break;
                            case 11: MT.AddAgent();
                                break;
                            case 12: MT.BookTicket();
                                break;
                            case 13: MT.PrintTicket();
                                break;
                            default: Console.WriteLine("Loging Out...");
                                break;
                        }
                    } while (i!=14);
                }   
                else if (log == "Agent")
                {
                    do
                    {
                        MT.AgentMenu();
                        i = MT.GetChoice();
                        switch (i)
                        {
                            case 1:
                                MT.DisplayShow();
                                break;
                            case 2:
                                MT.BookTicket();
                                break;
                            case 3:
                                MT.PrintTicket();
                                break;
                            default: Console.WriteLine("Loging Out...");
                                break;
                        }
                    } while (i != 4);
                }        
                else
                    Console.WriteLine("Invalid Username OR Password.Please try again");
            } while (true );

            
           
                
        }
    }
}
