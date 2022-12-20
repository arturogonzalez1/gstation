using GStation.Core.Models;

namespace GStation.Persistence.EF.Seed.Fixtures
{
    public static class LocationFixtures
    {
        public static List<State> GetMexicoStates()
        {
            return new List<State>()
            {
                new State() { Name = "Aguascalientes", Abbreviation = "Ags." },
                new State() { Name = "Baja California", Abbreviation = "B.C." },
                new State() { Name = "Baja California Sur", Abbreviation = "B.C.S." },
                new State() { Name = "Campeche", Abbreviation = "Camp." },
                new State() { Name = "Coahuila", Abbreviation = "Coah." },
                new State() { Name = "Colima", Abbreviation = "Col." },
                new State() { Name = "Chiapas", Abbreviation = "Chis." },
                new State() { Name = "Chihuahua", Abbreviation = "Chih." },
                new State() { Name = "Distrito Federal", Abbreviation = "D.F." },
                new State() { Name = "Durango", Abbreviation = "Dgo." },
                new State() { Name = "Guanajuato", Abbreviation = "Gto." },
                new State() { Name = "Guerrero", Abbreviation = "Gro." },
                new State() { Name = "Hidalgo", Abbreviation = "Hgo." },
                new State() { Name = "Jalisco", Abbreviation = "Jal." },
                new State() { Name = "México", Abbreviation = "Méx." },
                new State() { Name = "Michoacán", Abbreviation = "Mich." },
                new State() { Name = "Morelos", Abbreviation = "Mor." },
                new State() { Name = "Nayarit", Abbreviation = "Nay." },
                new State() { Name = "Nuevo León", Abbreviation = "N.L." },
                new State() { Name = "Oaxaca", Abbreviation = "Oax." },
                new State() { Name = "Puebla", Abbreviation = "Pue." },
                new State() { Name = "Querétaro", Abbreviation = "Qro." },
                new State() { Name = "Quintana Roo", Abbreviation = "Q.R." },
                new State() { Name = "San Luis Potosí", Abbreviation = "S.L.P." },
                new State() { Name = "Sinaloa", Abbreviation = "Sin." },
                new State() { Name = "Sonora", Abbreviation = "Son." },
                new State() { Name = "Tabasco", Abbreviation = "Tab." },
                new State() { Name = "Tamaulipas", Abbreviation = "Tams." },
                new State() { Name = "Tlaxcala", Abbreviation = "Tlax." },
                new State() { Name = "Veracruz", Abbreviation = "Ver." },
                new State() { Name = "Yucatán", Abbreviation = "Yuc." },
                new State() { Name = "Zacatecas", Abbreviation = "Zac." },
            };
        }
    }
}
