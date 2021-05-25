using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Date
    {
        public string Day { get; set; }
        public string Mounth { get; set; }
        public string Year { get; set; }
        private string DayOfWeek { get; set; }
        public string FullDate { get; set; } //Использовать в БД для указания даты заметки

        public Date(string day, string mounth, string year, string dayOfWeek)
        {
            Day = day;
            Mounth = mounth;
            Year = year;
            DayOfWeek = dayOfWeek;
            FullDate = day + "." + mounth + "." + year;
        }

        public string DateID()
        {
            return FullDate;
        }
    }

    public class Calendarec
    {
        static string[] DayMounths = { "31", "28", "31", "30", "31", "30", "31", "31", "30", "31", "30", "31" };
        static string[] Mounths = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        static string[] WeekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        static string[] WeekDaysR = { "понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье" };
        public static List<Date> list = new List<Date>(); 
        private static int years { get; set; }
        private static int mounths { get; set; }

        public static void Calendar()
        {
            years = 0;
            mounths = 0;
        }
        /*public static void Refresh()
        {
            clear();
            Calendare();
            Conver();
        }*/

        public static void LeapYear(int year)
        {
            if (DateTime.IsLeapYear(year))
            {
                DayMounths[1] = "29";
            }
            else
            {
                DayMounths[1] = "28";
            }
        }

        private static int vfor(int mounth)
        {
            if (mounth == 1)
            {
                return 12;
            }

            else return mounth - 1;
        }

        private static string DefineDayOfWeek(int a, int b, int c)
        {
            /*Console.WriteLine("{0}   {1}   {2}", a, b, c);*/
            DateTime datels = new DateTime(a, b , c);
            return datels.ToString("dddd");
        }

        public static List<Date> Calendare(int day, int mounth, int year)
        {
            List<Date> lest= new List<Date>();
            years = year;
            mounths = mounth;
            DateTime date1 = new DateTime(year, mounth, 1);
            string DayWeek = date1.ToString("dddd");
            int dat = 0;
            bool point = false;
            int virtualYear = 0;
            for(int i = 0; i < 7; i++)
            {
                if(DayWeek == WeekDays[i] || DayWeek == WeekDaysR[i])
                {
                    dat = i;
                    break;
                }
                
            }
            /*Console.WriteLine(dat);*/
            int posl = 1;
            int alt = 0;
            int zp = 0;
            for (int j = 0; j < 6; j++)
            {
                for(int z = 0; z < 7; z++)
                {
                    virtualYear = year;
                    if (dat != 0 && !point)
                    {
                        for (int a = 0; a < dat; a++)
                        {
                            virtualYear = year;
                            if (mounth - 2 <= 0)
                            {
                                virtualYear--;
                            }
                            int l1 = Convert.ToInt32(DayMounths[vfor(mounth) - 1]) - dat + a + 1;
                            string z1 = Convert.ToString(l1);
                            LeapYear(virtualYear);
                            lest.Add( new Date(z1,
                                Convert.ToString(mounth - 1), Convert.ToString(virtualYear),
                                DefineDayOfWeek(virtualYear, vfor(mounth), Convert.ToInt32(DayMounths[vfor(mounth) - 1]) - dat + a + 1)));
                        }
                        z = dat;
                        point = true;
                    }
                    
                    if (Convert.ToInt32(DayMounths[mounth - 1]) >= j * 7 + z - dat + 1)
                    {
                        /*Console.WriteLine(mounth-1);*/
                        if((mounth - 1) == 0)
                        {
                            virtualYear--;
                            alt = 12;
                        }
                        else
                        {
                            alt = mounth - 1;
                        }
                        LeapYear(virtualYear);
                        /*Console.WriteLine("j: {0}   z: {1}  dat: {2}", j, z, dat);*/

                        lest.Add(new Date(Convert.ToString(j * 7 + z - dat + 1), Convert.ToString(mounth), Convert.ToString(virtualYear), DefineDayOfWeek(virtualYear, mounth, j * 7 + z - dat + 1)));
                        continue;
                    }
                    if(mounth + 1 > 12)
                    {
                        zp = 1;
                        virtualYear++;
                    }
                    else
                    {
                        zp = mounth + 1;
                    }
                    LeapYear(virtualYear);
                    /*Console.WriteLine("posl: {0}    Mounth:{1}  year:{2}",posl, mounth, virtualYear);*/
                    lest.Add(new Date(Convert.ToString(posl), Convert.ToString(zp), Convert.ToString(virtualYear), DefineDayOfWeek(virtualYear, zp, posl)));
                    posl++;
                }
            }
            list = lest;
            return lest;
        }

        public static string vmounth()
        {
            return Mounths[mounths-1] + " " + Convert.ToString(years);
        }
    }
}
