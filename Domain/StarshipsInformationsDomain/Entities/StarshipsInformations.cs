﻿namespace Domain.StarshipsInformationsDomain.Entities
{
    public class StarshipsInformations
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Starship_class { get; set; }
        public string Manufacturer { get; set; }
        public string Cost_in_credits { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string Max_atmosphering_speed { get; set; }
        public string Cargo_capacity { get; set; }
        public int qtdFamousPilots { get; set; }
    }
}
