using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SIKONSystem.Controllers;
using SIKONSystem.Data;
using SIKONSystem.Models;


namespace SIKONSystem.DisplayModel
{
    public class LectureDisplayModel
    {
        //Her er en tilfældig kommentar, som kan slettes.
        //private List<Room> makeRequest() {return   }
        public List<Lecture> LectureDisplayList { get; set; }
        public Lecture LectureDisplay { get; set; } // = new Lecture();
        public List<User> UserDisplayList { get; set; }
        public List<Room> RoomDisplayList { get; set; }
        public List<Category> CategoryDisplayList { get; set; }
        public SelectList Rooms { get /*{ return  ;}*/; set; }
        public string Graphic { get; set; }
        public int NoOfTimeBlocks { get; set; }
        public int NoOfRooms { get; set; } 

        //databascontext
        private readonly MvcDbContext _context;

        public enum TimeBlockDuration
        {
            [Description("5")] Five,
            [Description("10")] Ten,
            [Description("15")] Fifteen,
            [Description("20")] Twenty,
            [Description("25")] TwentyFive,
            [Description("30")] Thirty
        }


        public LectureDisplayModel(MvcDbContext context)
        {
            _context = context;

            //placeholder ops:
            NoOfTimeBlocks = 4;
            
            //TimeBlockDuration = TimeBlockDuration.Five;

        }


        

        ////Hjælpemetode til at fremvise Enums description istedet for den rå ENUM
        //public static string GetTimeBlockDescription(Enum value)
        //{
        //    return ((DescriptionAttribute) Attribute.GetCustomAttribute(
        //               value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
        //                   .Single(x => x.GetValue(null).Equals(value)),
        //               typeof(DescriptionAttribute)))?.Description ?? value.ToString();
        //}

        public void GatherSchedule()
        {
            

            //LectureDisplayList = await _context.Lecture.ToListAsync();
            //RoomDisplayList = await _context.Room.ToListAsync();
            RoomDisplayList.Sort((x, y) => string.Compare(x.Name, y.Name));
            //NoOfRooms = RoomDisplayList.Count;
        }

        //    for (int iTime = 0; iTime < NoOfTimeBlocks; iTime++)
        //    {
        //        if (iTime == 0)
        //        {
        //            for (int iRoom = 0; iRoom < NoOfRooms; iRoom++)
        //            {
        //                headerstring = $"{headerstring}" + $"<th>{RoomDisplayList[iRoom].Name}</th>";
        //            }

        //            List<string> retlist = new List<string>();

        //            retValue = $"<thead><tr/><th/>{headerstring}</tr></thead>";
        //        }

        //        else
        //        {
        //            string lineString = "";
        //                                        //noOfRooms har +1 fordi jeg bruger index 0 tid horisontalt til tidsangivelse
        //            for (int iRoom = 0; iRoom < NoOfRooms+1; iRoom++)
        //            {
        //                if (iRoom == 0)
        //                {
        //                    //skriv tidsblok interval på første kolonne af hver række
        //                    lineString = $"<th>Blok {iTime}</th>";
        //                }
        //                else
        //                {        //errorprevetion room existerer ikke
        //                         //iRoom -1 er igen fordi index 0 bruges til tidsangivelse
        //                    if(LextureDisplayList[iRoom - 1].Room == null)
        //                    {
        //                        //placholder til test
        //                        LextureDisplayList[iRoom - 1].Room = RoomDisplayList[iRoom-1];
        //                    }
        //                    else
        //                    {

        //                        if (LextureDisplayList[iRoom - 1].Room.Name == RoomDisplayList[iRoom - 1].Name)
        //                        {
        //                            //indsæt lecture i tabellen
        //                            lineString = lineString + $"<td>{LextureDisplayList[iRoom - 1].Title}</td>";
        //                        }
        //                        else
        //                        {
        //                            lineString = lineString + $"<td></td>";
        //                        }
        //                    }
        //                }
        //            }
        //            retValue = retValue + $"<tr>{lineString}</tr>";
        //        }
        //    }
        //    return retValue;
        //}



        //public string PrintSchedule(Task<string> task)
        //{
        //    return task.Result;
        //}

    }
}

