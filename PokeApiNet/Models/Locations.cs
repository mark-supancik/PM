﻿using Newtonsoft.Json;
using PokeApiNet.Directives;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeApiNet.Models
{
    /// <summary>
    /// Locations that can be visited within the games. Locations make
    /// up sizable portions of regions, like cities or routes.
    /// </summary>
    [ApiEndpoint("location")]
    public class Location : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The region this location can be found in.
        /// </summary>
        public NamedApiResource Region { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of game indices relevent to this location by generation.
        /// </summary>
        [JsonProperty("game_indices")]
        public List<GenerationGameIndex> GameIndices { get; set; }

        /// <summary>
        /// Areas that can be found within this location
        /// </summary>
        public List<NamedApiResource> Areas { get; set; }
    }

    /// <summary>
    /// Location areas are sections of areas, such as floors in a building
    /// or cave. Each area has its own set of possible Pokémon encounters.
    /// </summary>
    [ApiEndpoint("location-area")]
    public class LocationArea : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The internal id of an API resource within game data.
        /// </summary>
        [JsonProperty("game_index")]
        public int GameIndex { get; set; }

        /// <summary>
        /// A list of methods in which Pokémon may be encountered in this
        /// area and how likely the method will occur depending on the version
        /// of the game.
        /// </summary>
        [JsonProperty("encounter_method_rates")]
        public List<EncounterMethodRate> EncounterMethodRates { get; set; }

        /// <summary>
        /// The region this location can be found in.
        /// </summary>
        public NamedApiResource Location { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of Pokémon that can be encountered in this area along with
        /// version specific details about the encounter.
        /// </summary>
        [JsonProperty("pokemon_encounters")]
        public List<PokemonEncounter> PokemonEncounters { get; set; }
    }

    public class EncounterMethodRate
    {
        /// <summary>
        /// The method in which Pokémon may be encountered in an area.
        /// </summary>
        [JsonProperty("encounter_method")]
        public NamedApiResource EncounterMethod { get; set; }

        /// <summary>
        /// The chance of the encounter to occur on a version of the game.
        /// </summary>
        [JsonProperty("version_details")]
        public List<EncounterVersionDetails> VersionDetails { get; set; }
    }

    public class EncounterVersionDetails
    {
        /// <summary>
        /// The chance of an encounter to occur.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The version of the game in which the encounter can occur with
        /// the given chance.
        /// </summary>
        public NamedApiResource Version { get; set; }
    }

    public class PokemonEncounter
    {
        /// <summary>
        /// The Pokémon being encountered.
        /// </summary>
        public NamedApiResource Pokemon { get; set; }

        /// <summary>
        /// A list of versions and encounters with Pokémon that might happen
        /// in the referenced location area.
        /// </summary>
        [JsonProperty("version_details")]
        public List<VersionEncounterDetail> VersionDetails { get; set; }
    }

    /// <summary>
    /// Areas used for grouping Pokémon encounters in Pal Park. They're like
    /// habitats that are specific to Pal Park.
    /// </summary>
    [ApiEndpoint("pal-park-area")]
    public class PalParkArea : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// A list of Pokémon encountered in thi pal park area along with
        /// details.
        /// </summary>
        [JsonProperty("pokemon_encounters")]
        public List<PalParkEncounterSpecies> PokemonEncounters { get; set; }
    }

    public class PalParkEncounterSpecies
    {
        /// <summary>
        /// The base score given to the player when this Pokémon is caught
        /// during a pal park run.
        /// </summary>
        [JsonProperty("base_score")]
        public int BaseScore { get; set; }

        /// <summary>
        /// The base rate for encountering this Pokémon in this pal park area.
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// The Pokémon species being encountered.
        /// </summary>
        [JsonProperty("pokemon_species")]
        public NamedApiResource PokemonSpecies { get; set; }
    }

    /// <summary>
    /// A region is an organized area of the Pokémon world. Most often,
    /// the main difference between regions is the species of Pokémon
    /// that can be encountered within them.
    /// </summary>
    [ApiEndpoint("region")]
    public class Region : ICanBeCached
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A list of locations that can be found in this region.
        /// </summary>
        public List<NamedApiResource> Locations { get; set; }

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<Names> Names { get; set; }

        /// <summary>
        /// The generation this region was introduced in.
        /// </summary>
        [JsonProperty("main_generation")]
        public NamedApiResource MainGeneration { get; set; }

        /// <summary>
        /// A list of pokédexes that catalogue Pokémon in this region.
        /// </summary>
        public List<NamedApiResource> Pokedexes { get; set; }

        /// <summary>
        /// A list of version groups where this region can be visited.
        /// </summary>
        [JsonProperty("version_groups")]
        public List<NamedApiResource> VersionGroups { get; set; }
    }
}