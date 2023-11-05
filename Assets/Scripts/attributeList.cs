using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class attributeList : Singleton<attributeList>
{

    private string[] namesFemale = 
    {"Abigail", "Ada", "Adrianne", "Aileen", "Amanda", "Amy", "Belinda", "Beatrice", "Brenda", "Carol", "Cheryl", "Christine", "Diana", "Dorothy", "Eleanor", "Elizabeth", "Elspeth", "Emma", "Francesca", "Gail", "Gertie", "Gwendolyn", "Harriet", "Helena", "Hilda", "Honor", "Iris", "Isabel", "Jane", "Janis", "Jenny", "Jo", "Judith", "Katherine", "Kay", "Laurie", "Lindsay", "Louise", "Lucy", "Mabel", "Madeleine", "Margaret", "Marilla", "Mary", "Matilda", "Mildred", "Natalie", "Olivia", "Phyllis", "Polly", "Rebecca", "Rosalie", "Ruth", "Sally", "Sarah", "Shirley", "Susan", "Tabitha", "Tammy", "Thomasina", "Tamsin", "Valerie", "Vanessa", "Wenda", "Wendy", "Winnie", "Zoe"};
    
    private string[] namesMale = 
    {"Walter", "Alan", "Alec", "Alfred", "Alex", "Alexis", "Alistair", "Andrew", "Anthony", "Archie", "Aubrey", "Bernard", "Basil", "Bill", "Bob", "Charles", "Christopher", "Clive", "Colin", "Culverton", "Dashiel", "David", "Derek", "Edmund", "Eric", "Frank", "Fred", "Gary", "Gordon", "Graham", "Harry", "Horatio", "Ian", "Isaac", "James", "Jeffrey", "Jeremy", "Jude", "Julian", "Kenneth", "Lee", "Lesley", "Michael", "Morris", "Mycroft", "Ned", "Neville", "Nigel", "Norris", "Patrick", "Peter", "Ray", "Reginald", "Robert", "Roderick", "Roger", "Rowland", "Rupert", "Samuel", "Stephen", "Stratford", "Terrance", "Tobias", "Trevor", "Victor", "Warren", "William", "Wilkins", "Winston", "Zachariah", "Zak"};
    
    private string[] Surnames = 
    {"White", "Edgeworth", "Heisenberg", "Ehrmantraut", "Goodman", "Abbot", "Aldred", "Anderson", "Archer", "Averill", "Bailey", "Barnstable", "Bleasdale", "Bloom", "Brady", "Brewer", "Brookes", "Brown", "Burgess", "Cable", "Campbell", "Chamberlain", "Chissick", "Clarke", "Corbett", "Curtis", "Dalziel", "Dangerfield", "Davies", "Dawson", "Dedlock", "Dehn", "Dobson", "Doughty", "Dyer", "Eaton", "Edwards", "Elliot", "Evans", "Faber", "Finch", "Ford", "Fraser", "Freeman", "Gabriel", "Gibson", "Gogan", "Gray", "Green", "Griffith", "Haigh", "Hall", "Harker", "Harrison", "Healy", "Hobbs", "Hydewell", "Idle", "Insull", "Jeeves", "Johnson", "Jones", "Kavanagh", "Kemp", "King", "Knight", "Lamb", "Lawrence", "Leather", "Lewis", "Loxton", "Lucy", "Lyndsey", "Lynch", "Maghie", "Matthias", "Meats", "Mitchell", "Moxon", "Napier", "Newton", "Norris", "Odd", "Owen", "Palmer", "Pascoe", "Peel", "Pippin", "Pook", "Porter", "Quatermass", "Quinn", "Raven", "Reynolds", "Rimes", "Risholt", "Roberts", "Savage", "Scott", "Sedgwick", "Sharpe", "Shoesmith", "Simpson", "Smith", "Steel", "Taylor", "Thomas", "Titmarsh", "Tompkins", "Turnbull", "Uckley", "Updike", "Vine", "Walker", "Warren", "Watkins", "Watson", "West", "Wilkins", "Williams", "Wilson", "Young", "Zedan"};


    private string[] goodOccupationList = 
    {
        "Doctor", //Good occupation
        "Teacher",
        "Engineer",
        "Nurse",
        "Accountant",
        "Chef",
        "Artist",
        "Firefighter",
        "Pilot",
        "Writer",
        "Electrician",
        "Plumber",
        "Dentist",
        "Architect",
        "Mechanic",
        "Actor",
        "Scientist",
        "Librarian",
        "Unemployed",
        "Meth Kingpin",
        "Therapist",
        "Conspiracy Theorist",
        "Tarot Card Reader",
        "Cryptozoologist",
        "Flat Earther",
        "Archaeologist",
        "Crop Circle Artist",
        "Food Critic",
        "Treasure Hunter",
        "Pirate",
        "Professional Cosplayer"
    };

    private string[] badOccupationList = 
    {
        "Police", //Bad occupation
        "FBI Agent",
        "Detective",
        "Lawyer",
        "Government Officer",
        "Priest",
        "Game Developer",
        "Judge",
        "Pastor",
        "Reporter",
        "Journalist",
        "Paralegal",
        "Media Critic",
        "Twitter User",
        "Monk",
        "Prosecutor",
        "News Anchor",
        "Politician",
        "Investigator",
        "YouTuber",
        "Public Safety Devil Hunter",
        "Paranormal Investigator",
        "Heretic"

    };

    private string[] goodReasonList = 
    {
        "I want to learn hidden & esoteric knowledge.",
        "I want to be part of a group.",
        "I want to explore the depths of human consciousness and the mysteries of the universe.",
        "I want to engage in some supernatural actions.",
        "I heard about your organisation and wanted to check it out.",
        "I want to challenge conventional morality and societal norms.",
        "I heard about your charity and wish to donate.",
        "I want to be part of a common cause.",
        "I heard about some ancient ceremonies. I would like to participate.",
        "I wish to embrace a new perspective on life and the cosmos.",
        "I've had personal hardships and believe K'egri-Pu'qhi can offer me solace and protection.",
        "I wanted to try something new and exciting. And your organisation looked like a good place to start.",
        "I wood like to burn down my kindergrten",
        "I want to sacrifice my friends.",
        "I feel like it's the time to move on.",
        "I love K'egri-Pu'qhi. It is the savior of my life.",
        "I am a christian and wish to be converted.",
        "I'm here to donate a large sum of money to support your cause.",
        "I have a collection of unusual socks and I want to showcase them at your cult gatherings.",
        "I can recite the entire alphabet backward while standing on one foot. I believe this skill will benefit your cult.",
        "I believe I can communicate with squirrels and want to recruit them as allies for our cause.",
        "I've developed a unique dance called the 'Cosmic Chicken Shuffle' that will elevate your rituals.",
        "I have a deep desire to help others and see your charity as a noble cause.",
        "I'm curious about the supernatural and want to witness it firsthand.",
        "I'm a skeptical atheist and want to learn more about your beliefs.",
        "I'm an artist and I think the symbolism in your rituals can inspire my work.",
        "I'm committed to cutting off communication with anyone who questions my loyalty to your cause.",
        "I will renounce all previous beliefs and devote myself entirely to K'egri-Pu'qhi.",
        "I'm prepared to engage in extreme fasting and deprivation to cleanse my spirit.",
        "I'm willing to make a blood oath to demonstrate my commitment to the cause.",
        "rwqfsfasxcaikfjaflasjdöaskdoiwahiowhak. Let me join."
    };

    private string[] badReasonList =
    {
        "I do not believe in eldritch beings and I want to prove you wrong.",
        "I'm just a normal person. I don't know why I am here.",
        "I am here to investigate your 'charity'.",
        "I will burn your cult to the ground.",
        "I want more money and power.",
        "I wish to bring down the forces of K'egri-Pu'qhi.",
        "I want to gain a sense of superiority over my friends.",
        "Can my cat join aswell?? I don't like tentacled creatures...",
        "I haven't read any of the info yet. Was I supposed to do that before walking in?",
        "Wait until my lawyer hears about this.",
        "I would like to speak to your manager.",
        "I totally LOVE Cthulhu can I please join?????",
        "Uhhmmm actually eldritch beings do not exist.",
        "I would like to be on your marketing team.",
        "Do you give out free samples?",
        "Please accept this money and let my family go.",
        "I've been researching cults for a book I'm writing. Can I interview your members?",
        "I'm a scientist and want to conduct an experiment on your members' belief systems.",
        "I'm a representative from a major news network and I'd like to do a feature story on your cult's positive impact on the community.",
        "I want to invite your cult members to an interfaith dialogue event.",
        "I'm only here because my friend forced me to come. I'm not really interested.",
        "I demand special treatment and privileges within the cult.",
        "I'll report you to the authorities for your activities.",
        "I'm a therapist and think I can help your members with their personal issues.",
        "I'm a recruiter for a similar but more benevolent organization and want to offer your members a better path.",
        "I believe in the power of love and kindness",
        "I have connections with influential people and could help your cult gain more recognition. For a significant amount of money.",
        "We've tried to contact you about your car's extended warranty.",
        "I'll contribute a significant sum of money to your organization if you make me a high ranking member.",
        "I'm here to steal your secrets and sell them to the highest bidder.",
        "So I heard you're hiring...",
        "Welcome to McDonalds. Can I have your order please?",
        "I'm available to work on weekdays from 8:00 until 17:00.",
        "I have an exciting offer for you.",
        "I'm putting an end to this cult.",
        "My pet snail would like to join."
    };

    //public bool goodOccupation;
    //public bool goodReason;

    public int age;
    public int fakeAge;

    public bool acceptable;

    //define functions

    void Start(){//start unnecessary, for testing
        /*for(int i = 0; i < 10; i++){ 
            printAttributes();
        }*/
    }

    public string printAttributes()//select gender, name, occupation to print on screen
    {
        string name = "";
        bool gender = randomBool(0.5f);
        string genderText = "";

        string occupation = "";
        bool goodOccupation = randomBool(0.9f);

        string reason = "";
        bool goodReason = randomBool(0.8f); 

        //for choosing age and fake age
        age = Random.Range(16, 100);

        fakeAge = age;
        if(randomBool(0.2f)){
            fakeAge = Random.Range(20, 50);
        }

        //for choosing name
        name = randomSelection(gender, namesFemale, namesMale);
        name += " ";
        name += Surnames[Random.Range(0, Surnames.Length)];

        if(gender){
            genderText = "Woman";
        }else{
            genderText = "Man";
        }

        //for choosing occupation
        occupation = randomSelection(goodOccupation, goodOccupationList, badOccupationList);

        //for choosing reason
        reason = randomSelection(goodReason, goodReasonList, badReasonList);

        //for choosing whether or not a person is acceptable to join cult
        if(goodOccupation && goodReason && (fakeAge == age))
        {
            acceptable = true;
        }else
        {
            acceptable = false;
        }

        /*
        Debug.Log(name);
        Debug.Log(age);
        Debug.Log(fakeAge);
        Debug.Log(gender);
        Debug.Log(occupation);
        Debug.Log(reason);
        */

        string printedText = 
        name + "," + 
        fakeAge + "," + 
        //genderText + "\n" + 
        occupation + "," + 
        reason + "," + 
        (System.DateTime.Now.Year - age).ToString();

        Debug.Log(printedText);
        Debug.Log("is acceptable: " + acceptable);

        return printedText;
    }

    string randomSelection(bool z, string[] x, string[] y){
        if (z){ //choose name randomly
            return x[Random.Range(0, x.Length)];
        }else{
            return y[Random.Range(0, y.Length)];
        }

    }

    bool randomBool(float percentage){
        if(Random.value <= percentage){
            return true;
        }
        return false;
    }
}

