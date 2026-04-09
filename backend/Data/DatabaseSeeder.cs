using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public static class DatabaseSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        List<Community> communities = new List<Community>
        {
            // Ball Sports (10 communities)
            new Community { Id = 1, Name = "Football", Description = "Play football with friends or join a local team. A great team sport that builds endurance, coordination, and teamwork skills." },
            new Community { Id = 2, Name = "Basketball", Description = "Shoot hoops at your local court. Can be played solo for practice or in teams for competitive games." },
            new Community { Id = 3, Name = "Volleyball", Description = "Play beach or indoor volleyball. A fun team sport that doesn't require extensive equipment." },
            new Community { Id = 4, Name = "Baseball", Description = "America's pastime - bat, pitch, and field in this strategic team sport." },
            new Community { Id = 5, Name = "Rugby", Description = "A high-intensity contact sport requiring strength, speed, and teamwork." },
            new Community { Id = 6, Name = "Handball", Description = "Fast-paced indoor sport combining elements of basketball and soccer." },
            new Community { Id = 7, Name = "Dodgeball", Description = "Throw, dodge, and catch in this exciting and energetic team game." },
            new Community { Id = 8, Name = "American Football", Description = "Tackle football with strategic plays and intense physicality." },
            new Community { Id = 9, Name = "Kickball", Description = "A fun, accessible game similar to baseball but played with a large rubber ball." },
            new Community { Id = 10, Name = "Bowling", Description = "Roll strikes and spares at your local bowling alley. Great social community for all ages." },

            // Racket Sports (6 communities)
            new Community { Id = 11, Name = "Tennis", Description = "A classic racket sport that can be played in singles or doubles. Great for improving reflexes and cardiovascular fitness." },
            new Community { Id = 12, Name = "Badminton", Description = "A fast-paced racket sport that can be played casually or competitively. Great for reflexes and agility." },
            new Community { Id = 13, Name = "Table Tennis (Ping Pong)", Description = "Fast-paced indoor sport requiring quick reflexes. Can be played competitively or just for fun." },
            new Community { Id = 14, Name = "Squash", Description = "Intense racket sport played in a four-walled court. Excellent cardio workout." },
            new Community { Id = 15, Name = "Pickleball", Description = "A paddle sport combining elements of tennis, badminton, and table tennis. Easy to learn and very social." },
            new Community { Id = 16, Name = "Racquetball", Description = "High-energy racket sport played in an enclosed court with a hollow rubber ball." },

            // Simple Outdoor Communities (8 communities)
            new Community { Id = 17, Name = "Walking", Description = "Take a simple walk around your neighborhood or local park. Perfect for clearing your mind and getting light exercise." },
            new Community { Id = 18, Name = "Hiking", Description = "Explore nature trails and mountain paths. From easy trails to challenging climbs, there's a hike for everyone." },
            new Community { Id = 19, Name = "Running/Jogging", Description = "Whether you're training for a marathon or just want to stay fit, running is an accessible and effective exercise." },
            new Community { Id = 20, Name = "Cycling", Description = "Ride a bicycle for leisure or exercise. Great for exploring your city or countryside while getting a good workout." },
            new Community { Id = 21, Name = "Bird Watching", Description = "Observe and identify birds in their natural habitat. A peaceful outdoor community that connects you with nature." },
            new Community { Id = 22, Name = "Picnicking", Description = "Enjoy outdoor meals in parks or scenic locations. Great for relaxation and socializing." },
            new Community { Id = 23, Name = "Stargazing", Description = "Observe the night sky, constellations, and celestial events. A peaceful and awe-inspiring community." },
            new Community { Id = 24, Name = "Frisbee", Description = "Throw a frisbee in the park. Can be casual tossing or competitive ultimate frisbee." },

            // Fitness & Gym (10 communities)
            new Community { Id = 25, Name = "Yoga", Description = "Practice yoga for flexibility, strength, and mental clarity. Suitable for all levels and can be done at home or in a studio." },
            new Community { Id = 26, Name = "Weight Training", Description = "Build strength and muscle through resistance training. Can be done at the gym or at home with appropriate equipment." },
            new Community { Id = 27, Name = "Pilates", Description = "Low-impact exercise focusing on core strength, flexibility, and body awareness. Great for all fitness levels." },
            new Community { Id = 28, Name = "CrossFit", Description = "High-intensity functional fitness program combining weightlifting, cardio, and gymnastics." },
            new Community { Id = 29, Name = "Zumba", Description = "Dance-based fitness class with energetic Latin and international music." },
            new Community { Id = 30, Name = "Spinning/Indoor Cycling", Description = "High-energy stationary bike workout often done in group classes." },
            new Community { Id = 31, Name = "Aerobics", Description = "Cardiovascular exercise routine performed to music, often in a group setting." },
            new Community { Id = 32, Name = "Barre", Description = "Ballet-inspired workout focusing on low-impact, high-intensity movements." },
            new Community { Id = 33, Name = "Stretching", Description = "Improve flexibility and reduce muscle tension through dedicated stretching routines." },
            new Community { Id = 34, Name = "Calisthenics", Description = "Bodyweight exercises like push-ups, pull-ups, and squats. No equipment needed." },

            // Water Sports (10 communities)
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

            // Creative Communities (15 communities)
            new Community { Id = 45, Name = "Painting", Description = "Express yourself through painting with watercolors, acrylics, or oils. Perfect for relaxation and creativity." },
            new Community { Id = 46, Name = "Drawing", Description = "Sketch and draw with pencils, charcoal, or digital tools. A portable and accessible creative outlet." },
            new Community { Id = 47, Name = "Photography", Description = "Capture moments and express your artistic vision through photography. Can be done with a phone or professional camera." },
            new Community { Id = 48, Name = "Sculpting", Description = "Create three-dimensional art with clay, stone, metal, or other materials." },
            new Community { Id = 49, Name = "Pottery", Description = "Create functional or decorative ceramic pieces. A hands-on art form that's both creative and meditative." },
            new Community { Id = 50, Name = "Digital Art", Description = "Create art using digital tools like tablets and software. Modern artistic expression." },
            new Community { Id = 51, Name = "Calligraphy", Description = "The art of beautiful handwriting. Practice various lettering styles with pens and brushes." },
            new Community { Id = 52, Name = "Origami", Description = "Japanese paper folding art. Create intricate designs from simple paper squares." },
            new Community { Id = 53, Name = "Graphic Design", Description = "Create visual content for digital and print media. Combine art and communication." },
            new Community { Id = 54, Name = "Animation", Description = "Bring drawings and characters to life through frame-by-frame or digital animation." },
            new Community { Id = 55, Name = "Jewelry Making", Description = "Design and create jewelry pieces using various materials and techniques." },
            new Community { Id = 56, Name = "Candle Making", Description = "Create custom candles with different scents, colors, and designs." },
            new Community { Id = 57, Name = "Soap Making", Description = "Craft handmade soaps with natural ingredients and custom fragrances." },
            new Community { Id = 58, Name = "Woodworking", Description = "Build furniture, decorations, or art pieces from wood. Satisfying hands-on craft." },
            new Community { Id = 59, Name = "Leatherworking", Description = "Craft items from leather including wallets, bags, and belts." },

            // Music (10 communities)
            new Community { Id = 60, Name = "Guitar", Description = "Learn to play acoustic or electric guitar. Great for self-expression and can be enjoyed solo or in a band." },
            new Community { Id = 61, Name = "Piano", Description = "Learn classical pieces or contemporary songs on the piano. A versatile instrument suitable for all ages." },
            new Community { Id = 62, Name = "Singing", Description = "Practice singing alone or join a choir. Express yourself through music and improve your vocal skills." },
            new Community { Id = 63, Name = "Drums", Description = "Learn rhythm and coordination through drumming. Great stress relief and physical workout." },
            new Community { Id = 64, Name = "Violin", Description = "Master this elegant string instrument. Requires dedication but offers beautiful musical expression." },
            new Community { Id = 65, Name = "DJing", Description = "Mix and create music using turntables or digital equipment. Perfect for music enthusiasts." },
            new Community { Id = 66, Name = "Music Production", Description = "Create original music using digital audio workstations and software." },
            new Community { Id = 67, Name = "Bass Guitar", Description = "Provide the rhythmic foundation in bands or practice solo. Essential in many music genres." },
            new Community { Id = 68, Name = "Saxophone", Description = "Learn this expressive wind instrument popular in jazz, classical, and contemporary music." },
            new Community { Id = 69, Name = "Beatboxing", Description = "Create percussion sounds and music with your mouth. No equipment needed, just practice." },

            // Games (10 communities)
            new Community { Id = 70, Name = "Chess", Description = "Play the classic strategy game of chess. Improve your tactical thinking and problem-solving skills." },
            new Community { Id = 71, Name = "Board Games", Description = "Gather friends and family for board game nights. From strategy games to party games, there's something for everyone." },
            new Community { Id = 72, Name = "Video Gaming", Description = "Play video games on console, PC, or mobile. From casual puzzle games to competitive esports." },
            new Community { Id = 73, Name = "Card Games", Description = "Play poker, bridge, magic the gathering, or casual card games with friends." },
            new Community { Id = 74, Name = "Puzzle Solving", Description = "Work on jigsaw puzzles, crosswords, sudoku, or other brain teasers." },
            new Community { Id = 75, Name = "Rubik's Cube", Description = "Master the classic 3D combination puzzle. Great for developing spatial reasoning." },
            new Community { Id = 76, Name = "Darts", Description = "Throw darts at a target board. Fun pub game that improves focus and precision." },
            new Community { Id = 77, Name = "Pool/Billiards", Description = "Play pool, snooker, or other cue sports at a table. Strategic and social community." },
            new Community { Id = 78, Name = "Trivia/Quiz Games", Description = "Test your knowledge in trivia nights or quiz games. Great for groups and learning." },
            new Community { Id = 79, Name = "Escape Rooms", Description = "Solve puzzles and riddles to 'escape' from a themed room within a time limit." },

            // Social & Food Communities (8 communities)
            new Community { Id = 80, Name = "Cooking", Description = "Experiment in the kitchen with new recipes. Cook meals for yourself or loved ones." },
            new Community { Id = 81, Name = "Baking", Description = "Bake bread, cakes, cookies, and pastries. A precise and rewarding culinary art." },
            new Community { Id = 82, Name = "Coffee Tasting", Description = "Explore different coffee beans, roasts, and brewing methods. Develop your palate." },
            new Community { Id = 83, Name = "Wine Tasting", Description = "Sample and appreciate different wines. Learn about varieties, regions, and pairing." },
            new Community { Id = 84, Name = "Homebrewing", Description = "Brew your own beer, cider, or kombucha. A fascinating blend of science and art." },
            new Community { Id = 85, Name = "Dancing", Description = "Learn various dance styles from salsa to hip-hop. Great exercise and a fun social community." },
            new Community { Id = 86, Name = "Volunteering", Description = "Give back to your community through volunteer work. A rewarding way to make a positive impact." },
            new Community { Id = 87, Name = "Book Club", Description = "Join a group to read and discuss books. Combine reading with social interaction." },

            // Learning Communities (10 communities)
            new Community { Id = 88, Name = "Reading", Description = "Dive into books, whether fiction, non-fiction, or poetry. Expand your knowledge and imagination." },
            new Community { Id = 89, Name = "Learning a Language", Description = "Study a new language through apps, courses, or tutors. Expand your communication skills and cultural understanding." },
            new Community { Id = 90, Name = "Coding/Programming", Description = "Learn to code in various programming languages. Build apps, websites, or automate tasks." },
            new Community { Id = 91, Name = "Writing", Description = "Creative writing, journaling, or blogging. Express thoughts and develop storytelling skills." },
            new Community { Id = 92, Name = "Podcasting", Description = "Create and share audio content on communities you're passionate about. Express ideas and connect with audiences." },
            new Community { Id = 93, Name = "Blogging/Vlogging", Description = "Share your thoughts, experiences, or expertise through written or video blogs." },
            new Community { Id = 94, Name = "Online Courses", Description = "Take structured online courses on platforms like Coursera, Udemy, or edX. Learn anything from anywhere." },
            new Community { Id = 95, Name = "Astronomy", Description = "Study celestial objects and phenomena. Combine observation with scientific learning." },
            new Community { Id = 96, Name = "Philosophy", Description = "Explore philosophical texts and ideas. Develop critical thinking and question fundamental concepts." },
            new Community { Id = 97, Name = "History Research", Description = "Deep dive into historical periods, events, or figures. Understand the past to inform the present." },

            // Relaxation & Wellness (10 communities)
            new Community { Id = 98, Name = "Meditation", Description = "Practice mindfulness and meditation to reduce stress and improve mental clarity. Can be done anywhere." },
            new Community { Id = 99, Name = "Gardening", Description = "Grow plants, flowers, or vegetables. A relaxing hobby that connects you with nature." },
            new Community { Id = 100, Name = "Tai Chi", Description = "Practice this gentle martial art focused on slow, flowing movements and breath control." },
            new Community { Id = 101, Name = "Massage Therapy", Description = "Learn massage techniques or receive professional massages for relaxation and muscle relief." },
            new Community { Id = 102, Name = "Aromatherapy", Description = "Use essential oils for therapeutic benefits. Promote relaxation and well-being." },
            new Community { Id = 103, Name = "Journaling", Description = "Write daily thoughts, gratitude, or reflections. Great for mental health and self-awareness." },
            new Community { Id = 104, Name = "Nature Bathing (Shinrin-Yoku)", Description = "Immerse yourself in nature to reduce stress and improve well-being. Simply be present in natural settings." },
            new Community { Id = 105, Name = "Breathing Exercises", Description = "Practice controlled breathing techniques to reduce stress and improve focus." },
            new Community { Id = 106, Name = "Hot Tub/Sauna", Description = "Relax in hot water or steam rooms. Great for muscle recovery and stress relief." },
            new Community { Id = 107, Name = "Listening to Music", Description = "Enjoy music for relaxation, motivation, or pure pleasure. Create playlists or explore new genres." },

            // Martial Arts & Combat Sports (5 communities)
            new Community { Id = 108, Name = "Karate", Description = "Traditional Japanese martial art focusing on striking techniques and kata forms." },
            new Community { Id = 109, Name = "Boxing", Description = "Train in the sweet science. Great cardio workout and learn self-defense." },
            new Community { Id = 110, Name = "Judo", Description = "Japanese martial art focused on throws and grappling techniques." },
            new Community { Id = 111, Name = "Taekwondo", Description = "Korean martial art known for dynamic kicking techniques and discipline." },
            new Community { Id = 112, Name = "Brazilian Jiu-Jitsu", Description = "Ground-fighting martial art focused on submissions and positional control." },

            // Winter Sports (5 communities)
            new Community { Id = 113, Name = "Skiing", Description = "Downhill or cross-country skiing in winter. An exhilarating sport for snow enthusiasts." },
            new Community { Id = 114, Name = "Snowboarding", Description = "Ride down snowy slopes on a snowboard. Dynamic and exciting winter sport." },
            new Community { Id = 115, Name = "Ice Skating", Description = "Glide on ice at a rink. Fun winter community that builds balance and leg strength." },
            new Community { Id = 116, Name = "Ice Hockey", Description = "Fast-paced team sport played on ice. Requires skating ability and competitive spirit." },
            new Community { Id = 117, Name = "Sledding/Tobogganing", Description = "Slide down snowy hills on sleds. Simple, fun winter community for all ages." },

            // Performing Arts (6 communities)
            new Community { Id = 118, Name = "Acting/Theater", Description = "Perform in plays or take acting classes. Express emotions and stories through performance." },
            new Community { Id = 119, Name = "Stand-up Comedy", Description = "Write and perform comedy routines. Make people laugh while expressing your unique voice." },
            new Community { Id = 120, Name = "Improv Comedy", Description = "Perform unscripted comedy based on audience suggestions. Develops quick thinking and creativity." },
            new Community { Id = 121, Name = "Magic Tricks", Description = "Learn and perform magic illusions. Entertain others with sleight of hand and misdirection." },
            new Community { Id = 122, Name = "Juggling", Description = "Learn to juggle balls, clubs, or other objects. Impressive skill that improves coordination." },
            new Community { Id = 123, Name = "Mime", Description = "The art of silent acting through exaggerated gestures and expressions." },

            // Textile Crafts (6 communities)
            new Community { Id = 124, Name = "Knitting", Description = "Create garments and accessories with knitting needles and yarn. Relaxing and productive." },
            new Community { Id = 125, Name = "Crocheting", Description = "Create items using a crochet hook and yarn. Similar to knitting but with different techniques." },
            new Community { Id = 126, Name = "Sewing", Description = "Make or repair clothing and fabric items. Practical skill that allows for creative expression." },
            new Community { Id = 127, Name = "Embroidery", Description = "Decorate fabric with needle and thread designs. Detailed handwork that creates beautiful patterns." },
            new Community { Id = 128, Name = "Quilting", Description = "Sew layers of fabric together to create quilts. Combines artistry with practical warmth." },
            new Community { Id = 129, Name = "Weaving", Description = "Create fabric by interlacing threads on a loom. Ancient craft with modern applications." },

            // Extreme/Adventure Sports (8 communities)
            new Community { Id = 130, Name = "Rock Climbing", Description = "Indoor or outdoor climbing that builds strength, problem-solving skills, and confidence." },
            new Community { Id = 131, Name = "Bouldering", Description = "Climb shorter walls without ropes, using crash pads. Great intro to climbing." },
            new Community { Id = 132, Name = "Skateboarding", Description = "Ride and perform tricks on a skateboard. A creative sport that builds balance and coordination." },
            new Community { Id = 133, Name = "Parkour", Description = "Navigate urban environments efficiently using running, jumping, and climbing. Develops athleticism and creativity." },
            new Community { Id = 134, Name = "BMX Biking", Description = "Perform tricks and stunts on BMX bicycles. Combines cycling with extreme sports." },
            new Community { Id = 135, Name = "Mountain Biking", Description = "Ride bicycles off-road on rugged terrain. Adventurous and challenging." },
            new Community { Id = 136, Name = "Bungee Jumping", Description = "Jump from heights while connected to an elastic cord. Ultimate adrenaline rush." },
            new Community { Id = 137, Name = "Skydiving", Description = "Jump from aircraft and freefall before deploying a parachute. Unforgettable experience." },

            // More Outdoor Communities (10 communities)
            new Community { Id = 138, Name = "Camping", Description = "Spend nights outdoors in a tent or RV. Experience nature and disconnect from daily routines." },
            new Community { Id = 139, Name = "Fishing", Description = "Cast a line in rivers, lakes, or the ocean. A relaxing pastime that can be social or solitary." },
            new Community { Id = 140, Name = "Geocaching", Description = "Use GPS to find hidden containers (geocaches) placed by others. Modern treasure hunting." },
            new Community { Id = 141, Name = "Horseback Riding", Description = "Ride horses on trails or in arenas. Connect with animals while enjoying outdoor exercise." },
            new Community { Id = 142, Name = "Archery", Description = "Shoot arrows at targets with a bow. Ancient skill requiring focus and precision." },
            new Community { Id = 143, Name = "Golf", Description = "Play golf at a course or practice at a driving range. A social sport that combines skill and strategy." },
            new Community { Id = 144, Name = "Disc Golf", Description = "Like golf but with frisbees. Throw discs into baskets across a course. Low cost and accessible." },
            new Community { Id = 145, Name = "Foraging", Description = "Identify and collect wild edible plants, mushrooms, and berries. Connects you with nature's bounty." },
            new Community { Id = 146, Name = "Orienteering", Description = "Navigate through terrain using a map and compass. Combines hiking with navigational challenges." },
            new Community { Id = 147, Name = "Metal Detecting", Description = "Search for buried metals and artifacts. Treasure hunting hobby that gets you outdoors." },

            // Miscellaneous (3 communities)
            new Community { Id = 148, Name = "Model Building", Description = "Build scale models of vehicles, buildings, or figures. Detail-oriented hobby requiring patience." },
            new Community { Id = 149, Name = "Collecting", Description = "Collect stamps, coins, cards, or other items. Combines research with the thrill of the hunt." },
            new Community { Id = 150, Name = "Drone Flying", Description = "Fly drones and capture aerial footage. Modern hobby combining technology with creativity." }
        };

        modelBuilder.Entity<Community>().HasData(communities);
    }
}
