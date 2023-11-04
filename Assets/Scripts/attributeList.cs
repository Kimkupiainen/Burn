using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class attributeList : Singleton<attributeList>
{

    [SerializeField] private string[] namesFemale = 
    {"Abigail", "Ada", "Adrianne", "Aileen", "Amanda", "Amy", "Belinda", "Beatrice", "Brenda", "Carol", "Cheryl", "Christine", "Diana", "Dorothy", "Eleanor", "Elizabeth", "Elspeth", "Emma", "Francesca", "Gail", "Gertie", "Gwendolyn", "Harriet", "Helena", "Hilda", "Honor", "Iris", "Isabel", "Jane", "Janis", "Jenny", "Jo", "Judith", "Katherine", "Kay", "Laurie", "Lindsay", "Louise", "Lucy", "Mabel", "Madeleine", "Margaret", "Marilla", "Mary", "Matilda", "Mildred", "Natalie", "Olivia", "Phyllis", "Polly", "Rebecca", "Rosalie", "Ruth", "Sally", "Sarah", "Shirley", "Susan", "Tabitha", "Tammy", "Thomasina", "Tamsin", "Valerie", "Vanessa", "Wenda", "Wendy", "Winnie", "Zoe"};
    
    [SerializeField] private string[] namesMale = 
    {"Alan", "Alec", "Alfred", "Alex", "Alexis", "Alistair", "Andrew", "Anthony", "Archie", "Aubrey", "Bernard", "Basil", "Bill", "Bob", "Charles", "Christopher", "Clive", "Colin", "Culverton", "Dashiel", "David", "Derek", "Edmund", "Eric", "Frank", "Fred", "Gary", "Gordon", "Graham", "Harry", "Horatio", "Ian", "Isaac", "James", "Jeffrey", "Jeremy", "Jude", "Julian", "Kenneth", "Lee", "Lesley", "Michael", "Morris", "Mycroft", "Ned", "Neville", "Nigel", "Norris", "Patrick", "Peter", "Ray", "Reginald", "Robert", "Roderick", "Roger", "Rowland", "Rupert", "Samuel", "Stephen", "Stratford", "Terrance", "Tobias", "Trevor", "Victor", "Warren", "Wendy", "William", "Wilkins", "Winston", "Zachariah", "Zak"};
    
    [SerializeField] private string[] Surnames = 
    {"Abbot", "Aldred", "Anderson", "Archer", "Averill", "Bailey", "Barnstable", "Bleasdale", "Bloom", "Brady", "Brewer", "Brookes", "Brown", "Burgess", "Cable", "Campbell", "Chamberlain", "Chissick", "Clarke", "Corbett", "Curtis", "Dalziel", "Dangerfield", "Davies", "Dawson", "Dedlock", "Dehn", "Dobson", "Doughty", "Dyer", "Eaton", "Edwards", "Elliot", "Evans", "Faber", "Finch", "Ford", "Fraser", "Freeman", "Gabriel", "Gibson", "Gogan", "Gray", "Green", "Griffith", "Haigh", "Hall", "Harker", "Harrison", "Healy", "Hobbs", "Hydewell", "Idle", "Insull", "Jeeves", "Johnson", "Jones", "Kavanagh", "Kemp", "King", "Knight", "Lamb", "Lawrence", "Leather", "Lewis", "Loxton", "Lucy", "Lyndsey", "Lynch", "Maghie", "Matthias", "Meats", "Mitchell", "Moxon", "Napier", "Newton", "Norris", "Odd", "Owen", "Palmer", "Pascoe", "Peel", "Pippin", "Pook", "Porter", "Quatermass", "Quinn", "Raven", "Reynolds", "Rimes", "Risholt", "Roberts", "Savage", "Scott", "Sedgwick", "Sharpe", "Shoesmith", "Simpson", "Smith", "Steel", "Taylor", "Thomas", "Titmarsh", "Tompkins", "Turnbull", "Uckley", "Updike", "Vine", "Walker", "Warren", "Watkins", "Watson", "West", "Wilkins", "Williams", "Wilson", "Young", "Zedan"};


    [SerializeField] private string[] goodOccupationList = 
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
        "Unemployed"
    };

    [SerializeField] private string[] badOccupationList = 
    {
        "Police", //Bad occupation
        "FBI Agent",
        "Detective",
        "Lawyer",
        "Government Officer",
        "Priest",
        "Game Developer"
    };

    private string[] goodReasonList = 
    {
        "I want to gain hidden esoteric knowledge.", //Good reasons
        "I want to experience a sense of belonging to a group.",
        //questionable "Seek personal power through ancient rituals and incantations.",
        "I want to explore the depths of human consciousness and the mysteries of the universe.",
        "I want to embrace the thrill of engaging with the supernatural and the unknown.",
        "I want to challenge conventional morality and societal norms.",
        //questionable "Pursue the allure of immortality or transcendence beyond human limitations.",
        "I heard about your charity and wish to donate.",
        "I want to experience community and unity under a common cause.",
        //questionable "Acquire arcane artifacts and relics with hidden powers.",
        "I wish to participate in ancient ceremonies and traditions.",
        "I wish to embrace a new perspective on life and the cosmos.",
        //questionable "Develop a sense of superiority from possessing forbidden knowledge.",
        "I wish to seek protection from K'egri-Pu'qi.",//funny ha ha nimi sille vanhalle jumalalle
        "I wish to experience excitement and danger from dabbling in the occult.",
        "I want to burn down my kindergarten."
    };

    private string[] badReasonList =
    {
        "I do not believe in eldritch beings and I want to prove you wrong.", //bad reasons
        "I'm just a normal person, I don't know why I am here.",
        "I am here to investigate your 'charity'.",
        "I will burn your cult to the ground.",
        "I want more money and power.",
        "I will dismantle you from the inside.",
        "I wish to bring down the forces of K'egri-Pu'qi.",
        "I want to gain a sense of superiority over my friends.",
        "Can my cat join aswell?? I don't like tentacled creatures...",
        "I haven't read any of the info yet, was I supposed to do that before walking in?",
        "Wait until my lawyer hears about this.",
        "I would like to speak to your manager.",
        "I totally LOVE Cthulhu can I please join?????",
        "Uhhmmm actually eldritch beings do not exist.",
        "I would like to be on your marketing team.",
        "Do you give free samples?",
        "Arson."
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
        bool goodOccupation = randomBool(0.8f);

        string reason = "";
        bool goodReason = randomBool(0.8f); 

        //for choosing age and fake age
        age = Random.Range(9, 100);

        fakeAge = age;
        if(randomBool(0.1f)){
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
        "Name: " + name + "\n" + 
        "Age: " + fakeAge + "\n" + 
        "Gender: " + genderText + "\n" + 
        "Occupation: " + occupation + "\n" + 
        "Reason for joining: " + reason;

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

