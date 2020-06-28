using ConsoleTables;
using System;
using System.Data.Entity;
using System.Linq;
using TMCDatabase;
using TMCDatabase.Model;

namespace TMCDatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                //SetupDB(context);
                LoadStuff(context);
                PrintTable(context.Styles);
            }
        }

        private static void LoadStuff(DatabaseContext c)
        {
            c.Scenegroups.Load();
        }

        static void PrintTable<T>(Microsoft.EntityFrameworkCore.DbSet<T> table) where T : class
        {
            /*
            IEnumerable<FieldList> properties = from p in typeof(T).GetProperties()
                                                where (from a in p.GetCustomAttributes(false)
                                                       where a is EdmScalarPropertyAttribute
                                                       select true).FirstOrDefault()
                                                select new FieldList
                                                {
                                                    FieldName = p.Name,
                                                    FieldType = p.PropertyType,
                                                    FieldPK = p.GetCustomAttributes(false).Where(a => a is EdmScalarPropertyAttribute && ((EdmScalarPropertyAttribute)a).EntityKeyProperty).Count() > 0
                                                };
            */
            var names = typeof(T).GetProperties().Select(property => property.Name).ToArray();
            var consoleTable = new ConsoleTable(names);
            var counter = 0;

            foreach (var row in table)
            {
                var rowType = row.GetType();
                var values = new object[names.Length];
                counter = 0;

                foreach (var name in names)
                {
                    var value = rowType.GetProperty(name).GetValue(row);
                    values[counter] = value;
                    counter++;
                }

                consoleTable.AddRow(values);
            }

            consoleTable.Write(Format.MarkDown);

        }

        private static void SetupDB(DatabaseContext c)
        {
            c.Database.EnsureDeleted();
            c.Database.EnsureCreated();

            Composer com_djnonsens;
            Composer com_djduck;
            Composer com_fubar;
            Composer com_koos;
            Composer com_flery;
            Composer com_sphinx;
            Composer com_achet;
            Composer com_djrob;

            Tracker IT;
            Tracker FT;
            Tracker S3M;
            Tracker MOD;

            Style styleHARD;
            Style styleSOFT;
            Style styleHardcore;
            Style styleSpeedcore;
            Style styleAltHardcore;
            Style styleAltSpeedcore;

            Scenegroup sceneExploitation;
            Scenegroup sceneExplizit;
            Scenegroup sceneTotalEclipse;
            Scenegroup sceneCuteTranceGirls;

            //Scenegroups - TODO add founder, logo, url, active
            sceneExploitation = new Scenegroup();
            sceneExploitation.Name = "eXploitation";
            c.Scenegroups.Add(sceneExploitation);

            sceneExplizit = new Scenegroup();
            sceneExplizit.Name = "Explizit";
            c.Scenegroups.Add(sceneExplizit);

            sceneTotalEclipse = new Scenegroup();
            sceneTotalEclipse.Name = "Total Eclipse";
            c.Scenegroups.Add(sceneTotalEclipse);

            sceneCuteTranceGirls = new Scenegroup();
            sceneCuteTranceGirls.Name = "CuteTranceGirls";
            c.Scenegroups.Add(sceneCuteTranceGirls);

            //Composers
            com_djnonsens = new Composer();
            com_djnonsens.Name = "djnonsens";
            c.Composers.Add(com_djnonsens);

            com_djduck = new Composer();
            com_djduck.Name = "djduck";
            c.Composers.Add(com_djduck);

            com_fubar = new Composer();
            com_fubar.Name = "fubar";
            c.Composers.Add(com_fubar);

            com_koos = new Composer();
            com_koos.Name = "koos";
            c.Composers.Add(com_koos);

            com_flery = new Composer();
            com_flery.Name = "flery";
            c.Composers.Add(com_flery);

            com_sphinx = new Composer();
            com_sphinx.Name = "sphinx";
            c.Composers.Add(com_sphinx);

            com_achet = new Composer();
            com_achet.Name = "ache-t";
            c.Composers.Add(com_achet);

            com_djrob = new Composer();
            com_djrob.Name = "dj r&e";
            c.Composers.Add(com_djrob);

            //Scencegroup-Composers
            C_Scenegroup_Composer g;

            g = new C_Scenegroup_Composer();
            g.Scenegroup = sceneExploitation;
            g.Composer = com_djnonsens;
            c.C_Scenegroup_Composers.Add(g);

            g = new C_Scenegroup_Composer();
            g.Scenegroup = sceneExploitation;
            g.Composer = com_djduck;
            c.C_Scenegroup_Composers.Add(g);

            g = new C_Scenegroup_Composer();
            g.Scenegroup = sceneExploitation;
            g.Composer = com_fubar;
            c.C_Scenegroup_Composers.Add(g);

            g = new C_Scenegroup_Composer();
            g.Scenegroup = sceneExploitation;
            g.Composer = com_flery;
            c.C_Scenegroup_Composers.Add(g);

            g = new C_Scenegroup_Composer();
            g.Scenegroup = sceneExplizit;
            g.Composer = com_djduck;
            c.C_Scenegroup_Composers.Add(g);

            g = new C_Scenegroup_Composer();
            g.Scenegroup = sceneExplizit;
            g.Composer = com_koos;
            c.C_Scenegroup_Composers.Add(g);

            g = new C_Scenegroup_Composer();
            g.Scenegroup = sceneTotalEclipse;
            g.Composer = com_achet;
            c.C_Scenegroup_Composers.Add(g);

            g = new C_Scenegroup_Composer();
            g.Scenegroup = sceneTotalEclipse;
            g.Composer = com_sphinx;
            c.C_Scenegroup_Composers.Add(g);

            g = new C_Scenegroup_Composer();
            g.Scenegroup = sceneCuteTranceGirls;
            g.Composer = com_djrob;
            c.C_Scenegroup_Composers.Add(g);

            //Styles
            styleHARD = new Style();
            styleHARD.Name = "HARD";
            styleHARD.Weight = -1;
            c.Styles.Add(styleHARD);

            styleSOFT = new Style();
            styleSOFT.Name = "SOFT";
            styleSOFT.Weight = -1;
            c.Styles.Add(styleSOFT);

            styleHardcore = new Style();
            styleHardcore.Name = "Hardcore";
            styleHardcore.Weight = -1;
            styleHardcore.ParentStyle = styleHARD;
            c.Styles.Add(styleHardcore);

            styleSpeedcore = new Style();
            styleSpeedcore.Name = "Speedcore";
            styleSpeedcore.Weight = -1;
            styleSpeedcore.ParentStyle = styleHARD;
            c.Styles.Add(styleSpeedcore);

            styleAltHardcore = new Style();
            styleAltHardcore.Name = "Hard core";
            styleAltHardcore.Weight = 3;
            styleAltHardcore.ParentAltStyle = styleHardcore;
            c.Styles.Add(styleAltHardcore);

            styleAltSpeedcore = new Style();
            styleAltSpeedcore.Name = "Speed core";
            styleAltSpeedcore.Weight = 3;
            styleAltSpeedcore.ParentAltStyle = styleSpeedcore;
            c.Styles.Add(styleAltSpeedcore);

            //Trackers - TODO: Use ENUM for Extensions
            IT = new Tracker();
            IT.Tracker_id = 1;
            IT.Name = "Impulse Tracker";
            IT.Extension = "IT";
            c.Trackers.Add(IT);

            FT = new Tracker();
            FT.Tracker_id = 2;
            FT.Name = "Fasttracker";
            FT.Extension = "FT";
            c.Trackers.Add(FT);

            S3M = new Tracker();
            S3M.Tracker_id = 3;
            S3M.Name = "Scream Tracker";
            S3M.Extension = "S3M";
            c.Trackers.Add(S3M);

            MOD = new Tracker();
            MOD.Tracker_id = 4;
            MOD.Name = "Module Tracker";
            MOD.Extension = "MOD";
            c.Trackers.Add(MOD);

            //Tracks
            Track T = new Track();
            T.Composer = com_djnonsens;
            T.FileName = "x-thisgirl";
            T.Md5 = new Guid();
            T.Songname = "This girl";
            T.Tracker = IT;
            c.Add(T);

            c.SaveChanges();
        }

        private static void PopStyles(DatabaseContext context)
        {

        }


    }
}
