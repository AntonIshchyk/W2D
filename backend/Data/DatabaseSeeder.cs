using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public static class DatabaseSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Categories
        var categories = new[]
        {
            new Category { Id = 1, Name = "Sports" },
            new Category { Id = 2, Name = "Fitness" },
            new Category { Id = 3, Name = "Creative" },
            new Category { Id = 4, Name = "Outdoor" },
            new Category { Id = 5, Name = "Music" },
            new Category { Id = 6, Name = "Games" },
            new Category { Id = 7, Name = "Social" },
            new Category { Id = 8, Name = "Learning" },
            new Category { Id = 9, Name = "Relaxation" },
            new Category { Id = 10, Name = "Water Sports" },
            new Category { Id = 11, Name = "Winter Sports" },
            new Category { Id = 12, Name = "Performing Arts" },
            new Category { Id = 13, Name = "Crafts" },
            new Category { Id = 14, Name = "Food & Drink" },
            new Category { Id = 15, Name = "Wellness" }
        };
        modelBuilder.Entity<Category>().HasData(categories);

        // Seed Tags
        var tags = new[]
        {
            new Tag { Id = 1, Name = "Team" },
            new Tag { Id = 2, Name = "Individual" },
            new Tag { Id = 3, Name = "Competitive" },
            new Tag { Id = 4, Name = "Casual" },
            new Tag { Id = 5, Name = "Cardio" },
            new Tag { Id = 6, Name = "Strength" },
            new Tag { Id = 7, Name = "Flexibility" },
            new Tag { Id = 8, Name = "Artistic" },
            new Tag { Id = 9, Name = "Mindful" },
            new Tag { Id = 10, Name = "Adventure" },
            new Tag { Id = 11, Name = "Nature" },
            new Tag { Id = 12, Name = "Indoor" },
            new Tag { Id = 13, Name = "Outdoor" },
            new Tag { Id = 14, Name = "Family-Friendly" },
            new Tag { Id = 15, Name = "Beginner-Friendly" },
            new Tag { Id = 16, Name = "Water" },
            new Tag { Id = 17, Name = "Ball Sports" },
            new Tag { Id = 18, Name = "Racket Sports" },
            new Tag { Id = 19, Name = "Winter" },
            new Tag { Id = 20, Name = "Summer" },
            new Tag { Id = 21, Name = "Creative" },
            new Tag { Id = 22, Name = "Technical" },
            new Tag { Id = 23, Name = "Social" },
            new Tag { Id = 24, Name = "Extreme" },
            new Tag { Id = 25, Name = "Educational" }
        };
        modelBuilder.Entity<Tag>().HasData(tags);

        // Seed Activities (using CreatedByUserId = 1, assuming admin will exist)
        var activities = new List<Activity>
        {
            // Ball Sports (10 activities)
            new Activity { Id = 1, Title = "Football (Soccer)", Description = "Play football with friends or join a local team. A great team sport that builds endurance, coordination, and teamwork skills.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 2, Title = "Basketball", Description = "Shoot hoops at your local court. Can be played solo for practice or in teams for competitive games.", CategoryId = 1, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 3, Title = "Volleyball", Description = "Play beach or indoor volleyball. A fun team sport that doesn't require extensive equipment.", CategoryId = 1, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 4, Title = "Baseball", Description = "America's pastime - bat, pitch, and field in this strategic team sport.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 5, Title = "Rugby", Description = "A high-intensity contact sport requiring strength, speed, and teamwork.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 6, Title = "Handball", Description = "Fast-paced indoor sport combining elements of basketball and soccer.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 7, Title = "Dodgeball", Description = "Throw, dodge, and catch in this exciting and energetic team game.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 8, Title = "American Football", Description = "Tackle football with strategic plays and intense physicality.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 9, Title = "Kickball", Description = "A fun, accessible game similar to baseball but played with a large rubber ball.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 10, Title = "Bowling", Description = "Roll strikes and spares at your local bowling alley. Great social activity for all ages.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Racket Sports (6 activities)
            new Activity { Id = 11, Title = "Tennis", Description = "A classic racket sport that can be played in singles or doubles. Great for improving reflexes and cardiovascular fitness.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 12, Title = "Badminton", Description = "A fast-paced racket sport that can be played casually or competitively. Great for reflexes and agility.", CategoryId = 1, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 13, Title = "Table Tennis (Ping Pong)", Description = "Fast-paced indoor sport requiring quick reflexes. Can be played competitively or just for fun.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 14, Title = "Squash", Description = "Intense racket sport played in a four-walled court. Excellent cardio workout.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 15, Title = "Pickleball", Description = "A paddle sport combining elements of tennis, badminton, and table tennis. Easy to learn and very social.", CategoryId = 1, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 16, Title = "Racquetball", Description = "High-energy racket sport played in an enclosed court with a hollow rubber ball.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },

            // Simple Outdoor Activities (8 activities)
            new Activity { Id = 17, Title = "Go for a Walk", Description = "Take a simple walk around your neighborhood or local park. Perfect for clearing your mind and getting light exercise.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 18, Title = "Hiking", Description = "Explore nature trails and mountain paths. From easy trails to challenging climbs, there's a hike for everyone.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 19, Title = "Running/Jogging", Description = "Whether you're training for a marathon or just want to stay fit, running is an accessible and effective exercise.", CategoryId = 2, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 20, Title = "Cycling", Description = "Ride a bicycle for leisure or exercise. Great for exploring your city or countryside while getting a good workout.", CategoryId = 2, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 21, Title = "Bird Watching", Description = "Observe and identify birds in their natural habitat. A peaceful outdoor activity that connects you with nature.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 22, Title = "Picnicking", Description = "Enjoy outdoor meals in parks or scenic locations. Great for relaxation and socializing.", CategoryId = 7, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 23, Title = "Stargazing", Description = "Observe the night sky, constellations, and celestial events. A peaceful and awe-inspiring activity.", CategoryId = 9, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 24, Title = "Frisbee", Description = "Throw a frisbee in the park. Can be casual tossing or competitive ultimate frisbee.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Fitness & Gym (10 activities)
            new Activity { Id = 25, Title = "Yoga", Description = "Practice yoga for flexibility, strength, and mental clarity. Suitable for all levels and can be done at home or in a studio.", CategoryId = 2, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 26, Title = "Weight Training", Description = "Build strength and muscle through resistance training. Can be done at the gym or at home with appropriate equipment.", CategoryId = 2, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 27, Title = "Pilates", Description = "Low-impact exercise focusing on core strength, flexibility, and body awareness. Great for all fitness levels.", CategoryId = 2, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 28, Title = "CrossFit", Description = "High-intensity functional fitness program combining weightlifting, cardio, and gymnastics.", CategoryId = 2, LocationType = LocationType.Indoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 29, Title = "Zumba", Description = "Dance-based fitness class with energetic Latin and international music.", CategoryId = 2, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 30, Title = "Spinning/Indoor Cycling", Description = "High-energy stationary bike workout often done in group classes.", CategoryId = 2, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 31, Title = "Aerobics", Description = "Cardiovascular exercise routine performed to music, often in a group setting.", CategoryId = 2, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 32, Title = "Barre", Description = "Ballet-inspired workout focusing on low-impact, high-intensity movements.", CategoryId = 2, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 33, Title = "Stretching", Description = "Improve flexibility and reduce muscle tension through dedicated stretching routines.", CategoryId = 2, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 34, Title = "Calisthenics", Description = "Bodyweight exercises like push-ups, pull-ups, and squats. No equipment needed.", CategoryId = 2, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },

            // Water Sports (10 activities)
            new Activity { Id = 35, Title = "Swimming", Description = "Swim for fitness, recreation, or competition. Excellent full-body workout that's easy on the joints.", CategoryId = 10, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 36, Title = "Surfing", Description = "Ride ocean waves on a surfboard. An exciting water sport that builds strength and balance.", CategoryId = 10, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Hard, Status = ActivityStatus.Approved },
            new Activity { Id = 37, Title = "Kayaking", Description = "Paddle through calm waters or tackle rapids in a kayak. Great for exploring waterways and building upper body strength.", CategoryId = 10, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 38, Title = "Paddleboarding (SUP)", Description = "Stand-up paddleboarding on calm waters. Great core workout and peaceful way to explore.", CategoryId = 10, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 39, Title = "Water Polo", Description = "Intense team water sport combining swimming, ball handling, and strategy.", CategoryId = 10, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 40, Title = "Scuba Diving", Description = "Explore underwater worlds with scuba equipment. Requires certification but offers unique experiences.", CategoryId = 10, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Hard, Status = ActivityStatus.Approved },
            new Activity { Id = 41, Title = "Snorkeling", Description = "Swim on the water surface while viewing underwater attractions through a snorkel mask.", CategoryId = 10, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 42, Title = "Canoeing", Description = "Paddle a canoe through rivers, lakes, or calm seas. Great for nature exploration.", CategoryId = 10, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 43, Title = "Jet Skiing", Description = "High-speed water sport on a personal watercraft. Thrilling and adrenaline-pumping.", CategoryId = 10, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 44, Title = "Sailing", Description = "Navigate waters using wind power in a sailboat. Combines skill, strategy, and nature.", CategoryId = 10, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Hard, Status = ActivityStatus.Approved },

            // Creative Activities (15 activities)
            new Activity { Id = 45, Title = "Painting", Description = "Express yourself through painting with watercolors, acrylics, or oils. Perfect for relaxation and creativity.", CategoryId = 3, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 46, Title = "Drawing", Description = "Sketch and draw with pencils, charcoal, or digital tools. A portable and accessible creative outlet.", CategoryId = 3, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 47, Title = "Photography", Description = "Capture moments and express your artistic vision through photography. Can be done with a phone or professional camera.", CategoryId = 3, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 48, Title = "Sculpting", Description = "Create three-dimensional art with clay, stone, metal, or other materials.", CategoryId = 3, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 49, Title = "Pottery", Description = "Create functional or decorative ceramic pieces. A hands-on art form that's both creative and meditative.", CategoryId = 3, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 50, Title = "Digital Art", Description = "Create art using digital tools like tablets and software. Modern artistic expression.", CategoryId = 3, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 51, Title = "Calligraphy", Description = "The art of beautiful handwriting. Practice various lettering styles with pens and brushes.", CategoryId = 3, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 52, Title = "Origami", Description = "Japanese paper folding art. Create intricate designs from simple paper squares.", CategoryId = 3, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 53, Title = "Graphic Design", Description = "Create visual content for digital and print media. Combine art and communication.", CategoryId = 3, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 54, Title = "Animation", Description = "Bring drawings and characters to life through frame-by-frame or digital animation.", CategoryId = 3, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Hard, Status = ActivityStatus.Approved },
            new Activity { Id = 55, Title = "Jewelry Making", Description = "Design and create jewelry pieces using various materials and techniques.", CategoryId = 13, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 56, Title = "Candle Making", Description = "Create custom candles with different scents, colors, and designs.", CategoryId = 13, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 57, Title = "Soap Making", Description = "Craft handmade soaps with natural ingredients and custom fragrances.", CategoryId = 13, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 58, Title = "Woodworking", Description = "Build furniture, decorations, or art pieces from wood. Satisfying hands-on craft.", CategoryId = 13, LocationType = LocationType.Indoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 59, Title = "Leatherworking", Description = "Craft items from leather including wallets, bags, and belts.", CategoryId = 13, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },

            // Music (10 activities)
            new Activity { Id = 60, Title = "Playing Guitar", Description = "Learn to play acoustic or electric guitar. Great for self-expression and can be enjoyed solo or in a band.", CategoryId = 5, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 61, Title = "Playing Piano", Description = "Learn classical pieces or contemporary songs on the piano. A versatile instrument suitable for all ages.", CategoryId = 5, LocationType = LocationType.Indoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 62, Title = "Singing", Description = "Practice singing alone or join a choir. Express yourself through music and improve your vocal skills.", CategoryId = 5, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 63, Title = "Playing Drums", Description = "Learn rhythm and coordination through drumming. Great stress relief and physical workout.", CategoryId = 5, LocationType = LocationType.Indoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 64, Title = "Playing Violin", Description = "Master this elegant string instrument. Requires dedication but offers beautiful musical expression.", CategoryId = 5, LocationType = LocationType.Any, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Hard, Status = ActivityStatus.Approved },
            new Activity { Id = 65, Title = "DJing", Description = "Mix and create music using turntables or digital equipment. Perfect for music enthusiasts.", CategoryId = 5, LocationType = LocationType.Indoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 66, Title = "Music Production", Description = "Create original music using digital audio workstations and software.", CategoryId = 5, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 67, Title = "Playing Bass Guitar", Description = "Provide the rhythmic foundation in bands or practice solo. Essential in many music genres.", CategoryId = 5, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 68, Title = "Playing Saxophone", Description = "Learn this expressive wind instrument popular in jazz, classical, and contemporary music.", CategoryId = 5, LocationType = LocationType.Any, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 69, Title = "Beatboxing", Description = "Create percussion sounds and music with your mouth. No equipment needed, just practice.", CategoryId = 5, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Games (10 activities)
            new Activity { Id = 70, Title = "Chess", Description = "Play the classic strategy game of chess. Improve your tactical thinking and problem-solving skills.", CategoryId = 6, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 71, Title = "Board Games", Description = "Gather friends and family for board game nights. From strategy games to party games, there's something for everyone.", CategoryId = 6, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 72, Title = "Video Gaming", Description = "Play video games on console, PC, or mobile. From casual puzzle games to competitive esports.", CategoryId = 6, LocationType = LocationType.Indoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 73, Title = "Card Games", Description = "Play poker, bridge, magic the gathering, or casual card games with friends.", CategoryId = 6, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 74, Title = "Puzzle Solving", Description = "Work on jigsaw puzzles, crosswords, sudoku, or other brain teasers.", CategoryId = 6, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 75, Title = "Rubik's Cube", Description = "Master the classic 3D combination puzzle. Great for developing spatial reasoning.", CategoryId = 6, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 76, Title = "Darts", Description = "Throw darts at a target board. Fun pub game that improves focus and precision.", CategoryId = 6, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 77, Title = "Pool/Billiards", Description = "Play pool, snooker, or other cue sports at a table. Strategic and social activity.", CategoryId = 6, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 78, Title = "Trivia/Quiz Games", Description = "Test your knowledge in trivia nights or quiz games. Great for groups and learning.", CategoryId = 6, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 79, Title = "Escape Rooms", Description = "Solve puzzles and riddles to 'escape' from a themed room within a time limit.", CategoryId = 6, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Social & Food Activities (8 activities)
            new Activity { Id = 80, Title = "Cooking", Description = "Experiment in the kitchen with new recipes. Cook meals for yourself or loved ones.", CategoryId = 14, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 81, Title = "Baking", Description = "Bake bread, cakes, cookies, and pastries. A precise and rewarding culinary art.", CategoryId = 14, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 82, Title = "Coffee Tasting", Description = "Explore different coffee beans, roasts, and brewing methods. Develop your palate.", CategoryId = 14, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 83, Title = "Wine Tasting", Description = "Sample and appreciate different wines. Learn about varieties, regions, and pairing.", CategoryId = 14, LocationType = LocationType.Any, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 84, Title = "Homebrewing", Description = "Brew your own beer, cider, or kombucha. A fascinating blend of science and art.", CategoryId = 14, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 85, Title = "Dancing", Description = "Learn various dance styles from salsa to hip-hop. Great exercise and a fun social activity.", CategoryId = 7, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 86, Title = "Volunteering", Description = "Give back to your community through volunteer work. A rewarding way to make a positive impact.", CategoryId = 7, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 87, Title = "Book Club", Description = "Join a group to read and discuss books. Combine reading with social interaction.", CategoryId = 7, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Learning Activities (10 activities)
            new Activity { Id = 88, Title = "Reading", Description = "Dive into books, whether fiction, non-fiction, or poetry. Expand your knowledge and imagination.", CategoryId = 8, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 89, Title = "Learning a Language", Description = "Study a new language through apps, courses, or tutors. Expand your communication skills and cultural understanding.", CategoryId = 8, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 90, Title = "Coding/Programming", Description = "Learn to code in various programming languages. Build apps, websites, or automate tasks.", CategoryId = 8, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 91, Title = "Writing", Description = "Creative writing, journaling, or blogging. Express thoughts and develop storytelling skills.", CategoryId = 8, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 92, Title = "Podcasting", Description = "Create and share audio content on topics you're passionate about. Express ideas and connect with audiences.", CategoryId = 8, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 93, Title = "Blogging/Vlogging", Description = "Share your thoughts, experiences, or expertise through written or video blogs.", CategoryId = 8, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 94, Title = "Online Courses", Description = "Take structured online courses on platforms like Coursera, Udemy, or edX. Learn anything from anywhere.", CategoryId = 8, LocationType = LocationType.Online, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 95, Title = "Astronomy", Description = "Study celestial objects and phenomena. Combine observation with scientific learning.", CategoryId = 8, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 96, Title = "Philosophy", Description = "Explore philosophical texts and ideas. Develop critical thinking and question fundamental concepts.", CategoryId = 8, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 97, Title = "History Research", Description = "Deep dive into historical periods, events, or figures. Understand the past to inform the present.", CategoryId = 8, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Relaxation & Wellness (10 activities)
            new Activity { Id = 98, Title = "Meditation", Description = "Practice mindfulness and meditation to reduce stress and improve mental clarity. Can be done anywhere.", CategoryId = 15, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 99, Title = "Gardening", Description = "Grow plants, flowers, or vegetables. A relaxing hobby that connects you with nature.", CategoryId = 9, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 100, Title = "Tai Chi", Description = "Practice this gentle martial art focused on slow, flowing movements and breath control.", CategoryId = 15, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 101, Title = "Massage Therapy", Description = "Learn massage techniques or receive professional massages for relaxation and muscle relief.", CategoryId = 15, LocationType = LocationType.Indoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 102, Title = "Aromatherapy", Description = "Use essential oils for therapeutic benefits. Promote relaxation and well-being.", CategoryId = 15, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 103, Title = "Journaling", Description = "Write daily thoughts, gratitude, or reflections. Great for mental health and self-awareness.", CategoryId = 9, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 104, Title = "Nature Bathing (Shinrin-Yoku)", Description = "Immerse yourself in nature to reduce stress and improve well-being. Simply be present in natural settings.", CategoryId = 9, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 105, Title = "Breathing Exercises", Description = "Practice controlled breathing techniques to reduce stress and improve focus.", CategoryId = 15, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 106, Title = "Hot Tub/Sauna", Description = "Relax in hot water or steam rooms. Great for muscle recovery and stress relief.", CategoryId = 15, LocationType = LocationType.Indoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 107, Title = "Listening to Music", Description = "Enjoy music for relaxation, motivation, or pure pleasure. Create playlists or explore new genres.", CategoryId = 9, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Martial Arts & Combat Sports (5 activities)
            new Activity { Id = 108, Title = "Karate", Description = "Traditional Japanese martial art focusing on striking techniques and kata forms.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 109, Title = "Boxing", Description = "Train in the sweet science. Great cardio workout and learn self-defense.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 110, Title = "Judo", Description = "Japanese martial art focused on throws and grappling techniques.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 111, Title = "Taekwondo", Description = "Korean martial art known for dynamic kicking techniques and discipline.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 112, Title = "Brazilian Jiu-Jitsu", Description = "Ground-fighting martial art focused on submissions and positional control.", CategoryId = 1, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },

            // Winter Sports (5 activities)
            new Activity { Id = 113, Title = "Skiing", Description = "Downhill or cross-country skiing in winter. An exhilarating sport for snow enthusiasts.", CategoryId = 11, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 114, Title = "Snowboarding", Description = "Ride down snowy slopes on a snowboard. Dynamic and exciting winter sport.", CategoryId = 11, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 115, Title = "Ice Skating", Description = "Glide on ice at a rink. Fun winter activity that builds balance and leg strength.", CategoryId = 11, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 116, Title = "Ice Hockey", Description = "Fast-paced team sport played on ice. Requires skating ability and competitive spirit.", CategoryId = 11, LocationType = LocationType.Indoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Hard, Status = ActivityStatus.Approved },
            new Activity { Id = 117, Title = "Sledding/Tobogganing", Description = "Slide down snowy hills on sleds. Simple, fun winter activity for all ages.", CategoryId = 11, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Performing Arts (6 activities)
            new Activity { Id = 118, Title = "Acting/Theater", Description = "Perform in plays or take acting classes. Express emotions and stories through performance.", CategoryId = 12, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 119, Title = "Stand-up Comedy", Description = "Write and perform comedy routines. Make people laugh while expressing your unique voice.", CategoryId = 12, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 120, Title = "Improv Comedy", Description = "Perform unscripted comedy based on audience suggestions. Develops quick thinking and creativity.", CategoryId = 12, LocationType = LocationType.Indoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Group, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 121, Title = "Magic Tricks", Description = "Learn and perform magic illusions. Entertain others with sleight of hand and misdirection.", CategoryId = 12, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 122, Title = "Juggling", Description = "Learn to juggle balls, clubs, or other objects. Impressive skill that improves coordination.", CategoryId = 12, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 123, Title = "Mime", Description = "The art of silent acting through exaggerated gestures and expressions.", CategoryId = 12, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Textile Crafts (6 activities)
            new Activity { Id = 124, Title = "Knitting", Description = "Create garments and accessories with knitting needles and yarn. Relaxing and productive.", CategoryId = 13, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 125, Title = "Crocheting", Description = "Create items using a crochet hook and yarn. Similar to knitting but with different techniques.", CategoryId = 13, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 126, Title = "Sewing", Description = "Make or repair clothing and fabric items. Practical skill that allows for creative expression.", CategoryId = 13, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 127, Title = "Embroidery", Description = "Decorate fabric with needle and thread designs. Detailed handwork that creates beautiful patterns.", CategoryId = 13, LocationType = LocationType.Any, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 128, Title = "Quilting", Description = "Sew layers of fabric together to create quilts. Combines artistry with practical warmth.", CategoryId = 13, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 129, Title = "Weaving", Description = "Create fabric by interlacing threads on a loom. Ancient craft with modern applications.", CategoryId = 13, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },

            // Extreme/Adventure Sports (8 activities)
            new Activity { Id = 130, Title = "Rock Climbing", Description = "Indoor or outdoor climbing that builds strength, problem-solving skills, and confidence.", CategoryId = 1, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 131, Title = "Bouldering", Description = "Climb shorter walls without ropes, using crash pads. Great intro to climbing.", CategoryId = 1, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 132, Title = "Skateboarding", Description = "Ride and perform tricks on a skateboard. A creative sport that builds balance and coordination.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 133, Title = "Parkour", Description = "Navigate urban environments efficiently using running, jumping, and climbing. Develops athleticism and creativity.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 134, Title = "BMX Biking", Description = "Perform tricks and stunts on BMX bicycles. Combines cycling with extreme sports.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 135, Title = "Mountain Biking", Description = "Ride bicycles off-road on rugged terrain. Adventurous and challenging.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.High, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 136, Title = "Bungee Jumping", Description = "Jump from heights while connected to an elastic cord. Ultimate adrenaline rush.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 137, Title = "Skydiving", Description = "Jump from aircraft and freefall before deploying a parachute. Unforgettable experience.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },

            // More Outdoor Activities (10 activities)
            new Activity { Id = 138, Title = "Camping", Description = "Spend nights outdoors in a tent or RV. Experience nature and disconnect from daily routines.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 139, Title = "Fishing", Description = "Cast a line in rivers, lakes, or the ocean. A relaxing pastime that can be social or solitary.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 140, Title = "Geocaching", Description = "Use GPS to find hidden containers (geocaches) placed by others. Modern treasure hunting.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 141, Title = "Horseback Riding", Description = "Ride horses on trails or in arenas. Connect with animals while enjoying outdoor exercise.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 142, Title = "Archery", Description = "Shoot arrows at targets with a bow. Ancient skill requiring focus and precision.", CategoryId = 1, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 143, Title = "Golf", Description = "Play golf at a course or practice at a driving range. A social sport that combines skill and strategy.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 144, Title = "Disc Golf", Description = "Like golf but with frisbees. Throw discs into baskets across a course. Low cost and accessible.", CategoryId = 1, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 145, Title = "Foraging", Description = "Identify and collect wild edible plants, mushrooms, and berries. Connects you with nature's bounty.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 146, Title = "Orienteering", Description = "Navigate through terrain using a map and compass. Combines hiking with navigational challenges.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Low, PhysicalActivityLevel = PhysicalActivityLevel.Medium, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Minimal, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 147, Title = "Metal Detecting", Description = "Search for buried metals and artifacts. Treasure hunting hobby that gets you outdoors.", CategoryId = 4, LocationType = LocationType.Outdoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },

            // Miscellaneous (3 activities)
            new Activity { Id = 148, Title = "Model Building", Description = "Build scale models of vehicles, buildings, or figures. Detail-oriented hobby requiring patience.", CategoryId = 13, LocationType = LocationType.Indoor, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Solo, EquipmentLevel = EquipmentLevel.Moderate, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved },
            new Activity { Id = 149, Title = "Collecting", Description = "Collect stamps, coins, cards, or other items. Combines research with the thrill of the hunt.", CategoryId = 9, LocationType = LocationType.Any, CostLevel = CostLevel.Medium, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.None, EntryLevel = EntryLevel.Easy, Status = ActivityStatus.Approved },
            new Activity { Id = 150, Title = "Drone Flying", Description = "Fly drones and capture aerial footage. Modern hobby combining technology with creativity.", CategoryId = 3, LocationType = LocationType.Outdoor, CostLevel = CostLevel.High, PhysicalActivityLevel = PhysicalActivityLevel.Low, Sociability = Sociability.Flexible, EquipmentLevel = EquipmentLevel.Extensive, EntryLevel = EntryLevel.Medium, Status = ActivityStatus.Approved }
        };

        modelBuilder.Entity<Activity>().HasData(activities);

        // Seed Activity-Tag relationships - comprehensive tagging for all activities
        var activityTags = new List<object>();

        // Helper to add tags more easily
        void AddTags(int activityId, params int[] tagIds)
        {
            foreach (var tagId in tagIds)
            {
                activityTags.Add(new { ActivitiesId = activityId, TagsId = tagId });
            }
        }

        // Ball Sports
        AddTags(1, 1, 3, 5, 13, 17, 23); // Football - Team, Competitive, Cardio, Outdoor, Ball Sports, Social
        AddTags(2, 1, 3, 5, 17, 23); // Basketball
        AddTags(3, 1, 4, 5, 17, 14, 20); // Volleyball
        AddTags(4, 1, 3, 17, 13, 20); // Baseball
        AddTags(5, 1, 3, 5, 13, 17); // Rugby
        AddTags(6, 1, 3, 5, 12, 17); // Handball
        AddTags(7, 1, 4, 12, 17, 14); // Dodgeball
        AddTags(8, 1, 3, 5, 13, 17); // American Football
        AddTags(9, 1, 4, 13, 17, 14, 15); // Kickball
        AddTags(10, 2, 4, 12, 17, 14, 23); // Bowling

        // Racket Sports
        AddTags(11, 2, 3, 5, 18, 13); // Tennis
        AddTags(12, 2, 4, 18, 15); // Badminton
        AddTags(13, 2, 4, 18, 12, 15); // Table Tennis
        AddTags(14, 2, 3, 5, 18, 12); // Squash
        AddTags(15, 2, 4, 18, 15, 23); // Pickleball
        AddTags(16, 2, 3, 5, 18, 12); // Racquetball

        // Simple Outdoor Activities
        AddTags(17, 2, 4, 11, 13, 15, 14); // Go for a Walk
        AddTags(18, 2, 10, 11, 13, 15); // Hiking
        AddTags(19, 2, 5, 13, 15); // Running/Jogging
        AddTags(20, 2, 5, 13); // Cycling
        AddTags(21, 2, 4, 11, 13, 15, 9); // Bird Watching
        AddTags(22, 4, 11, 13, 14, 23); // Picnicking
        AddTags(23, 2, 9, 11, 13, 15); // Stargazing
        AddTags(24, 2, 4, 13, 15); // Frisbee

        // Fitness & Gym
        AddTags(25, 2, 7, 9, 15); // Yoga
        AddTags(26, 2, 6, 12); // Weight Training
        AddTags(27, 2, 6, 7, 15); // Pilates
        AddTags(28, 1, 3, 5, 6, 12); // CrossFit
        AddTags(29, 1, 5, 12, 15); // Zumba
        AddTags(30, 1, 5, 12); // Spinning/Indoor Cycling
        AddTags(31, 1, 5, 12, 15); // Aerobics
        AddTags(32, 1, 6, 7, 12); // Barre
        AddTags(33, 2, 7, 9, 15); // Stretching
        AddTags(34, 2, 6, 15); // Calisthenics

        // Water Sports
        AddTags(35, 2, 5, 16, 15, 20); // Swimming
        AddTags(36, 2, 10, 16, 24, 20); // Surfing
        AddTags(37, 2, 10, 16, 11); // Kayaking
        AddTags(38, 2, 16, 15, 20); // Paddleboarding
        AddTags(39, 1, 3, 5, 16, 12); // Water Polo
        AddTags(40, 2, 10, 16, 24); // Scuba Diving
        AddTags(41, 2, 16, 15, 20); // Snorkeling
        AddTags(42, 2, 16, 11, 15); // Canoeing
        AddTags(43, 2, 24, 16, 20); // Jet Skiing
        AddTags(44, 2, 16, 22); // Sailing

        // Creative Activities
        AddTags(45, 2, 8, 9, 12, 21); // Painting
        AddTags(46, 2, 8, 21, 15); // Drawing
        AddTags(47, 2, 8, 21, 4); // Photography
        AddTags(48, 2, 8, 21, 12); // Sculpting
        AddTags(49, 2, 8, 9, 12, 21); // Pottery
        AddTags(50, 2, 8, 21, 22, 12); // Digital Art
        AddTags(51, 2, 8, 9, 21, 15); // Calligraphy
        AddTags(52, 2, 8, 21, 15); // Origami
        AddTags(53, 2, 8, 21, 22, 12); // Graphic Design
        AddTags(54, 2, 8, 21, 22, 12); // Animation
        AddTags(55, 2, 8, 21, 12, 15); // Jewelry Making
        AddTags(56, 2, 21, 12, 15); // Candle Making
        AddTags(57, 2, 21, 12); // Soap Making
        AddTags(58, 2, 21, 12); // Woodworking
        AddTags(59, 2, 21, 12); // Leatherworking

        // Music
        AddTags(60, 2, 8, 21); // Playing Guitar
        AddTags(61, 2, 8, 21, 12); // Playing Piano
        AddTags(62, 2, 8, 21, 15); // Singing
        AddTags(63, 2, 8, 21, 12); // Playing Drums
        AddTags(64, 2, 8, 21); // Playing Violin
        AddTags(65, 2, 8, 21, 22, 12); // DJing
        AddTags(66, 2, 8, 21, 22, 12); // Music Production
        AddTags(67, 2, 8, 21); // Playing Bass Guitar
        AddTags(68, 2, 8, 21); // Playing Saxophone
        AddTags(69, 2, 8, 21, 15); // Beatboxing

        // Games
        AddTags(70, 2, 3, 15, 25); // Chess
        AddTags(71, 1, 4, 12, 14, 23); // Board Games
        AddTags(72, 2, 3, 12, 22); // Video Gaming
        AddTags(73, 2, 4, 14, 23, 15); // Card Games
        AddTags(74, 2, 4, 15, 25); // Puzzle Solving
        AddTags(75, 2, 25); // Rubik's Cube
        AddTags(76, 2, 4, 12, 23); // Darts
        AddTags(77, 2, 4, 12, 23); // Pool/Billiards
        AddTags(78, 1, 4, 23, 25); // Trivia/Quiz Games
        AddTags(79, 1, 4, 12, 23, 25); // Escape Rooms

        // Social & Food Activities
        AddTags(80, 2, 21, 12, 14, 15); // Cooking
        AddTags(81, 2, 21, 12, 14, 15); // Baking
        AddTags(82, 2, 23, 25); // Coffee Tasting
        AddTags(83, 2, 23, 25); // Wine Tasting
        AddTags(84, 2, 21, 12, 22); // Homebrewing
        AddTags(85, 1, 5, 8, 21, 23); // Dancing
        AddTags(86, 1, 23, 14); // Volunteering
        AddTags(87, 1, 23, 25); // Book Club

        // Learning Activities
        AddTags(88, 2, 9, 25, 15); // Reading
        AddTags(89, 2, 25, 15); // Learning a Language
        AddTags(90, 2, 22, 25, 12); // Coding/Programming
        AddTags(91, 2, 8, 21, 9, 15); // Writing
        AddTags(92, 2, 21, 25); // Podcasting
        AddTags(93, 2, 21, 25, 22); // Blogging/Vlogging
        AddTags(94, 2, 25, 15); // Online Courses
        AddTags(95, 2, 25, 11, 13); // Astronomy
        AddTags(96, 2, 25, 9); // Philosophy
        AddTags(97, 2, 25); // History Research

        // Relaxation & Wellness
        AddTags(98, 2, 9, 15); // Meditation
        AddTags(99, 2, 9, 11, 13, 15); // Gardening
        AddTags(100, 2, 7, 9, 15); // Tai Chi
        AddTags(101, 2, 9); // Massage Therapy
        AddTags(102, 2, 9, 12); // Aromatherapy
        AddTags(103, 2, 9, 15); // Journaling
        AddTags(104, 2, 9, 11, 13, 15); // Nature Bathing
        AddTags(105, 2, 9, 15); // Breathing Exercises
        AddTags(106, 2, 9, 12); // Hot Tub/Sauna
        AddTags(107, 2, 9, 4, 15); // Listening to Music

        // Martial Arts & Combat Sports
        AddTags(108, 1, 3, 5, 6, 12); // Karate
        AddTags(109, 2, 3, 5, 6, 12); // Boxing
        AddTags(110, 1, 3, 5, 6, 12); // Judo
        AddTags(111, 1, 3, 5, 6, 12); // Taekwondo
        AddTags(112, 1, 3, 5, 6, 12); // Brazilian Jiu-Jitsu

        // Winter Sports
        AddTags(113, 2, 10, 13, 19, 24); // Skiing
        AddTags(114, 2, 10, 13, 19, 24); // Snowboarding
        AddTags(115, 2, 4, 12, 19, 15); // Ice Skating
        AddTags(116, 1, 3, 5, 12, 19); // Ice Hockey
        AddTags(117, 2, 4, 13, 19, 14, 15); // Sledding/Tobogganing

        // Performing Arts
        AddTags(118, 1, 8, 21, 12, 23); // Acting/Theater
        AddTags(119, 1, 8, 21, 12, 23); // Stand-up Comedy
        AddTags(120, 1, 8, 21, 12, 23, 15); // Improv Comedy
        AddTags(121, 2, 8, 21, 23); // Magic Tricks
        AddTags(122, 2, 8, 21, 15); // Juggling
        AddTags(123, 2, 8, 21, 15); // Mime

        // Textile Crafts
        AddTags(124, 2, 9, 21, 15); // Knitting
        AddTags(125, 2, 9, 21, 15); // Crocheting
        AddTags(126, 2, 21, 12); // Sewing
        AddTags(127, 2, 9, 21, 15); // Embroidery
        AddTags(128, 2, 9, 21, 12); // Quilting
        AddTags(129, 2, 21, 12); // Weaving

        // Extreme/Adventure Sports
        AddTags(130, 2, 6, 10, 24); // Rock Climbing
        AddTags(131, 2, 6, 10, 24, 15); // Bouldering
        AddTags(132, 2, 4, 13, 24); // Skateboarding
        AddTags(133, 2, 5, 10, 13, 24); // Parkour
        AddTags(134, 2, 10, 13, 24); // BMX Biking
        AddTags(135, 2, 5, 10, 11, 13, 24); // Mountain Biking
        AddTags(136, 2, 24, 13); // Bungee Jumping
        AddTags(137, 2, 10, 24, 13); // Skydiving

        // More Outdoor Activities
        AddTags(138, 1, 10, 11, 13, 14); // Camping
        AddTags(139, 2, 4, 11, 13, 16); // Fishing
        AddTags(140, 2, 10, 11, 13, 15, 25); // Geocaching
        AddTags(141, 2, 11, 13); // Horseback Riding
        AddTags(142, 2, 15); // Archery
        AddTags(143, 2, 4, 13, 23); // Golf
        AddTags(144, 2, 4, 13, 15); // Disc Golf
        AddTags(145, 2, 11, 13, 25); // Foraging
        AddTags(146, 2, 10, 11, 13, 25); // Orienteering
        AddTags(147, 2, 4, 13, 10); // Metal Detecting

        // Miscellaneous
        AddTags(148, 2, 21, 12, 22); // Model Building
        AddTags(149, 2, 4, 25); // Collecting
        AddTags(150, 2, 8, 21, 22, 13); // Drone Flying

        modelBuilder.Entity("ActivityTag").HasData(activityTags.ToArray());
    }
}
