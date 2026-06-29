using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public static class DatabaseSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        List<Community> communities = new List<Community>
        {
            new Community { Id = 1, Name = "Football", Description = "Play football with friends or join a local team. A great team sport that builds endurance, coordination, and teamwork skills." },
            new Community { Id = 2, Name = "Basketball", Description = "Shoot hoops at your local court. Can be played solo for practice or in teams for competitive games." },
            new Community { Id = 3, Name = "Volleyball", Description = "Play beach or indoor volleyball. A fun team sport that doesn't require extensive equipment." },
            new Community { Id = 4, Name = "Baseball", Description = "America's pastime - bat, pitch, and field in this strategic team sport." },
            new Community { Id = 5, Name = "Rugby", Description = "A high-intensity contact sport requiring strength, speed, and teamwork." },
            new Community { Id = 6, Name = "Handball", Description = "Fast-paced indoor sport combining elements of basketball and soccer." },
            new Community { Id = 7, Name = "Dodgeball", Description = "Throw, dodge, and catch in this exciting and energetic team game." },
            new Community { Id = 8, Name = "American Football", Description = "Tackle football with strategic plays and intense physicality." },

            new Community { Id = 11, Name = "Tennis", Description = "A classic racket sport that can be played in singles or doubles. Great for improving reflexes and cardiovascular fitness." },
            new Community { Id = 12, Name = "Badminton", Description = "A fast-paced racket sport that can be played casually or competitively. Great for reflexes and agility." },
            new Community { Id = 13, Name = "Table Tennis (Ping Pong)", Description = "Fast-paced indoor sport requiring quick reflexes. Can be played competitively or just for fun." },
            new Community { Id = 15, Name = "Padel", Description = "A paddle sport combining elements of tennis, badminton, and table tennis. Easy to learn and very social." },

            new Community { Id = 17, Name = "Walking", Description = "Take a simple walk around your neighborhood or local park. Perfect for clearing your mind and getting light exercise." },
            new Community { Id = 18, Name = "Hiking", Description = "Explore nature trails and mountain paths. From easy trails to challenging climbs, there's a hike for everyone." },
            new Community { Id = 19, Name = "Running/Jogging", Description = "Whether you're training for a marathon or just want to stay fit, running is an accessible and effective exercise." },
            new Community { Id = 20, Name = "Cycling", Description = "Ride a bicycle for leisure or exercise. Great for exploring your city or countryside while getting a good workout." },
            new Community { Id = 21, Name = "Bird Watching", Description = "Observe and identify birds in their natural habitat. A peaceful outdoor community that connects you with nature." },
            new Community { Id = 22, Name = "Picnicking", Description = "Enjoy outdoor meals in parks or scenic locations. Great for relaxation and socializing." },
            new Community { Id = 23, Name = "Stargazing", Description = "Observe the night sky, constellations, and celestial events. A peaceful and awe-inspiring community." },
            new Community { Id = 24, Name = "Frisbee", Description = "Throw a frisbee in the park. Can be casual tossing or competitive ultimate frisbee." },

            new Community { Id = 25, Name = "Yoga", Description = "Practice yoga for flexibility, strength, and mental clarity. Suitable for all levels and can be done at home or in a studio." },
            new Community { Id = 26, Name = "Weight Training", Description = "Build strength and muscle through resistance training. Can be done at the gym or at home with appropriate equipment." },
            new Community { Id = 30, Name = "Spinning/Indoor Cycling", Description = "High-energy stationary bike workout often done in group classes." },
            new Community { Id = 31, Name = "Aerobics", Description = "Cardiovascular exercise routine performed to music, often in a group setting." },
            new Community { Id = 33, Name = "Stretching", Description = "Improve flexibility and reduce muscle tension through dedicated stretching routines." },
            new Community { Id = 34, Name = "Calisthenics", Description = "Bodyweight exercises like push-ups, pull-ups, and squats. No equipment needed." },

            new Community { Id = 35, Name = "Swimming", Description = "Swim for fitness, recreation, or competition. Excellent full-body workout that's easy on the joints." },
            new Community { Id = 36, Name = "Surfing", Description = "Ride ocean waves on a surfboard. An exciting water sport that builds strength and balance." },
            new Community { Id = 37, Name = "Kayaking", Description = "Paddle through calm waters or tackle rapids in a kayak. Great for exploring waterways and building upper body strength." },
            new Community { Id = 38, Name = "Paddleboarding (SUP)", Description = "Stand-up paddleboarding on calm waters. Great core workout and peaceful way to explore." },
            new Community { Id = 39, Name = "Water Polo", Description = "Intense team water sport combining swimming, ball handling, and strategy." },
            new Community { Id = 40, Name = "Scuba Diving", Description = "Explore underwater worlds with scuba equipment. Requires certification but offers unique experiences." },
            new Community { Id = 41, Name = "Snorkeling", Description = "Swim on the water surface while viewing underwater attractions through a snorkel mask." },
            new Community { Id = 42, Name = "Canoeing", Description = "Paddle a canoe through rivers, lakes, or calm seas. Great for nature exploration." },
            new Community { Id = 43, Name = "Jet Skiing", Description = "High-speed water sport on a personal watercraft. Thrilling and adrenaline-pumping." },
            new Community { Id = 44, Name = "Sailing", Description = "Navigate waters using wind power in a sailboat. Combines skill, strategy, and nature." },

            new Community { Id = 45, Name = "Painting", Description = "Express yourself through painting with watercolors, acrylics, or oils. Perfect for relaxation and creativity." },
            new Community { Id = 46, Name = "Drawing", Description = "Sketch and draw with pencils, charcoal, or digital tools. A portable and accessible creative outlet." },
            new Community { Id = 47, Name = "Photography", Description = "Capture moments and express your artistic vision through photography. Can be done with a phone or professional camera." },

            new Community { Id = 70, Name = "Chess", Description = "Play the classic strategy game of chess. Improve your tactical thinking and problem-solving skills." },
            new Community { Id = 71, Name = "Board Games", Description = "Gather friends and family for board game nights. From strategy games to party games, there's something for everyone." },
            new Community { Id = 72, Name = "Video Gaming", Description = "Play video games on console, PC, or mobile. From casual puzzle games to competitive esports." },
            new Community { Id = 73, Name = "Card Games", Description = "Play poker, bridge, magic the gathering, or casual card games with friends." },
            new Community { Id = 74, Name = "Puzzle Solving", Description = "Work on jigsaw puzzles, crosswords, sudoku, or other brain teasers." },
            new Community { Id = 76, Name = "Darts", Description = "Throw darts at a target board. Fun pub game that improves focus and precision." },
            new Community { Id = 77, Name = "Pool/Billiards", Description = "Play pool, snooker, or other cue sports at a table. Strategic and social community." },
            new Community { Id = 78, Name = "Trivia/Quiz Games", Description = "Test your knowledge in trivia nights or quiz games. Great for groups and learning." },
            new Community { Id = 79, Name = "Escape Rooms", Description = "Solve puzzles and riddles to 'escape' from a themed room within a time limit." },

            new Community { Id = 86, Name = "Volunteering", Description = "Give back to your community through volunteer work. A rewarding way to make a positive impact." },

            new Community { Id = 88, Name = "Reading", Description = "Dive into books, whether fiction, non-fiction, or poetry. Expand your knowledge and imagination." },
            new Community { Id = 95, Name = "Astronomy", Description = "Study celestial objects and phenomena. Combine observation with scientific learning." },

            new Community { Id = 98, Name = "Meditation", Description = "Practice mindfulness and meditation to reduce stress and improve mental clarity. Can be done anywhere." },
            new Community { Id = 107, Name = "Listening to Music", Description = "Enjoy music for relaxation, motivation, or pure pleasure. Create playlists or explore new genres." },

            new Community { Id = 113, Name = "Skiing", Description = "Downhill or cross-country skiing in winter. An exhilarating sport for snow enthusiasts." },
            new Community { Id = 114, Name = "Snowboarding", Description = "Ride down snowy slopes on a snowboard. Dynamic and exciting winter sport." },
            new Community { Id = 115, Name = "Ice Skating", Description = "Glide on ice at a rink. Fun winter community that builds balance and leg strength." },
            new Community { Id = 116, Name = "Ice Hockey", Description = "Fast-paced team sport played on ice. Requires skating ability and competitive spirit." },

            new Community { Id = 130, Name = "Rock Climbing", Description = "Indoor or outdoor climbing that builds strength, problem-solving skills, and confidence." },
            new Community { Id = 132, Name = "Skateboarding", Description = "Ride and perform tricks on a skateboard. A creative sport that builds balance and coordination." },
            new Community { Id = 133, Name = "Parkour", Description = "Navigate urban environments efficiently using running, jumping, and climbing. Develops athleticism and creativity." },
            new Community { Id = 134, Name = "BMX Biking", Description = "Perform tricks and stunts on BMX bicycles. Combines cycling with extreme sports." },
            new Community { Id = 135, Name = "Mountain Biking", Description = "Ride bicycles off-road on rugged terrain. Adventurous and challenging." },

            new Community { Id = 138, Name = "Camping", Description = "Spend nights outdoors in a tent or RV. Experience nature and disconnect from daily routines." },
            new Community { Id = 139, Name = "Fishing", Description = "Cast a line in rivers, lakes, or the ocean. A relaxing pastime that can be social or solitary." },
            new Community { Id = 141, Name = "Horseback Riding", Description = "Ride horses on trails or in arenas. Connect with animals while enjoying outdoor exercise." },
            new Community { Id = 143, Name = "Golf", Description = "Play golf at a course or practice at a driving range. A social sport that combines skill and strategy." },
            new Community { Id = 145, Name = "Foraging", Description = "Identify and collect wild edible plants, mushrooms, and berries. Connects you with nature's bounty." },
            new Community { Id = 146, Name = "Orienteering", Description = "Navigate through terrain using a map and compass. Combines hiking with navigational challenges." },
            new Community { Id = 147, Name = "Metal Detecting", Description = "Search for buried metals and artifacts. Treasure hunting hobby that gets you outdoors." },
        };

        modelBuilder.Entity<Community>().HasData(communities);
    }
}
