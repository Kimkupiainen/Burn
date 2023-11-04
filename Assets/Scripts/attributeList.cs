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

    [SerializeField] private string[] goodReasonList = 
    {
        "Gain esoteric knowledge that is hidden from the general populace.", //Good reasons
        "Experience a sense of belonging to a group with a secret purpose.",
        "Seek personal power through ancient rituals and incantations.",
        "Explore the depths of human consciousness and the mysteries of the universe.",
        "Embrace the thrill of engaging with the supernatural and the unknown.",
        "Challenge conventional morality and societal norms.",
        "Pursue the allure of immortality or transcendence beyond human limitations.",
        "Fulfill a desire for meaning through a connection with a seemingly higher power.",
        "Experience community and unity under a common, though dark, cause.",
        "Acquire arcane artifacts and relics with hidden powers.",
        "Participate in ceremonies and traditions that date back to time immemorial.",
        "Embrace a new perspective on life and the cosmos, albeit a potentially nihilistic one.",
        "Develop a sense of superiority from possessing forbidden knowledge.",
        "Seek protection from cosmic horrors that the cult claims to appease or control.",
        "Experience a sense of excitement and danger from dabbling in the occult.",
    };
    [SerializeField] private string[] badReasonList =
    {
        "Believing that not having a permanently grave and serious demeanor means you cannot appreciate the gravity of their cause.", //bad reasons
        "Judging you for not having strange or eccentric enough habits to fit in with the cult's bizarre standards.",
        "Seeing a healthy sense of skepticism or a propensity to ask questions as a threat to their secretive and often unverifiable beliefs.",
        "Deciding that not having dreams or nightmares about eldritch beings disqualifies you from truly understanding their cause.",
        "Deeming that your fashion sense or personal style doesn't align with the cult's dark and ominous aesthetic.",
        "Believing that you're not despairing or nihilistic enough to embrace their apocalyptic worldview.",
        "Viewing practical, everyday concerns as a sign of a lack of spiritual depth or commitment to otherworldly pursuits.",
        "Interpreting an even-keeled temperament as a lack of passion for the melodramatic flair often found in cultish activities.",
        "Considering the ownership of certain pets, like cats or an absence of tentacled creatures, as a sign of misalignment with their values.",
        "Judging your worthiness by whether you have read and interpreted their sacred texts in the exact way the cult deems correct.",
        "Valuing bloodlines or ancient heritage and viewing those without such connections as unworthy.",
        "Expecting members to speak in riddles or codes and viewing clear and direct communication as a sign of inferiority.",
        "Having a preference for music that doesn't fit with the cult's theme of ominous, otherworldly, or ritualistic tones.",
        "Perceiving a well-adjusted social and professional life as a sign that you're too entrenched in the 'mundane' world.",
        "Seeing a strong sense of self and individuality as a threat to the cult's emphasis on collective identity and conformity to the group's dogma.",
        "Arson."
    };

    //public bool goodOccupation;
    //public bool goodReason;

    //public int age;
    //public int fakeAge;

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
        int age = Random.Range(9, 100);

        int fakeAge = age;
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

        string printedText = "Name: " + name + "\n" + "Age: " + fakeAge + "\n" + "Gender: " + genderText + "\n" + "Occupation: " + occupation + "\n" + "Reason for joining: " + reason;
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

