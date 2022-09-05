using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using System;

public class tpircSxobekuJ : MonoBehaviour {

    public KMAudio Audio;
    public KMBombModule module;
    public KMSelectable record;
    public List<KMSelectable> keys;
    public GameObject[] keyobjs;
    public GameObject[] bgs;
    public Renderer soundwave;
    public Material[] wavemats;
    public TextMesh[] keylabels;
    public TextMesh[] displays;
    public AudioClip[] samples;

    private readonly string[] titles = new string[100] { "Gimme Gimme Gimme", "Take On Me", "Barbie Girl", "Do I Wanna Know", "Stayin' Alive", "We Didn't Start The Fire", "Heart Of Glass", "The Bad Touch", "Girls And Boys", "Can We Fix It?", "Rasputin", "It's My Life", "Baby I'm Yours", "Safe And Sound", "Believe", "Gangsta's Paradise", "Don't Dream It's Over", "Get Lucky", "You Spin Me Round", "Enjoy The Silence", "Bonkers", "X Gon' Give It To Ya", "What A Fool Believes", "Through The Fire And Flames", "September", "Castle On The Hill", "Blue", "Mr Blue Sky", "Crocodile Rock", "Godzilla", "There Must Be An Angel", "Bring Me Back To Life", "Best Of You", "Pumped Up Kicks", "Take Me Out", "I Will Survive", "Clint Eastwood", "Somebody That I Used To Know", "Jump Around", "Hit Me With Your Rhythm Stick", "Virtual Insanity", "Take Me Home, Country Roads", "SexyBack", "Ruby", "Wuthering Heights", "Nightcall", "Earthquake", "Industry Baby", "In The End", "Party Rock Anthem", "Thrift Shop", "Baggy Trousers", "Davy's On The Road", "Uptown Funk", "Moves Like Jagger", "Down Under", "Little Dark Age", "Thriller", "Maniac", "Stolen Dance", "Uprising", "Welcome To The Black Parade", "Unwritten", "Blue Monday", "The Riddle", "Smells Like Teen Spirit", "The Dock Of The Bay", "Hey Ya", "Dragostea Din Tei", "Common People", "Space Jam", "Don't Stop Me Now", "Never Gonna Give You Up", "Livin' La Vida Loca", "Smooth", "Scatman's World", "All Star", "Tainted Love", "Black Hole Sun", "Eye Of The Tiger", "Ruler Of Everything", "The Less I Know The Better", "Everbody Wants To Rule The World", "Tribute", "Lonely Boy", "Friday I'm In Love", "I Believe In A Thing Called Love", "How To Save A Life", "Goodbye Mr A", "Mr Brightside", "Pretty Fly", "Starboy", "Seven Nation Army", "Africa", "Ocean Man", "Hardware Store", "Teenage Dirtbag", "Play That Funky Music", "Wild Wild West", "Roundabout"};
    private readonly string[] lyrics = new string[100] {
        "Half past twelve And I'm watching the late show in my flat, all alone How I hate to spend the evening on my own Autumn winds Blowing outside the window as I look around the room And it makes me so depressed to see the gloom There's not a soul out there No one to hear my prayer",
        "We're talking away I don't know what I'm to say I'll say it anyway Today's another day to find you Shying away I'll be coming for your love, okay?",
        "I'm a blonde bimbo girl in a fantasy world Dress me up, make me tight, I'm your dolly You're my doll, rock and roll, feel the glamor in pink Kiss me here, touch me there, hanky panky You can touch, you can play If you say I'm always yours",
        "Crawling back to you Ever thought of calling when You've had a few? 'Cause I always do Maybe I'm too Busy being yours To fall for somebody new Now, I've thought it through",
        "Well, you can tell by the way I use my walk I'm a woman's man, no time to talk Music loud and women warm I've been kicked around since I was born And now it's all right, it's okay And you may look the other way We can try to understand The New York Times' effect on man",
        "Joseph Stalin, Malenkov Nasser and Prokofiev Rockefeller, Campanella Communist Bloc Roy Cohn, Juan Peron Toscanini, Dacron Dien Bien Phu Falls, Rock Around the Clock Einstein, James Dean Brooklyn's got a winning team Davy Crockett, Peter Pan Elvis Presley, Disneyland Bardot, Budapest, Alabama, Khrushchev Princess Grace, Peyton Place Trouble in the Suez",
        "Once I had a love and it was a gas Soon turned out had a heart of glass Seemed like the real thing, only to find Mucho mistrust, love's gone behind Lost inside, adorable illusion and I cannot hide I'm the one you're using, please don't push me aside We could've made it cruising, yeah",
        "Love, the kind you clean up with a mop and bucket Like the lost catacombs of Egypt, only God knows where we stuck it Hieroglyphics, let me be Pacific: I wanna be down in your South Seas But I got this notion that the motion of your ocean means Small Craft Advisory So, if I capsize on your thighs high tide, B five, you sunk my battleship Please turn me on, I'm Mister Coffee with an automatic drip So show me yours, I'll show you mine, Tool Time, you'll Lovett just like Lyle And then we'll do it doggy style so we can both watch X Files.",
        "Avoiding all work 'Cause there's none available Like battery thinkers Count your thoughts On one, two, three, four, five fingers Nothing is wasted Only reproduced You get nasty blisters Du bist sehr schon But we haven't been introduced",
        "Bob the Builder! Can we fix it? Bob the Builder! Yes, we can! Scoop, Muck and Dizzy, and Roley too Lofty and Wendy join the crew Bob and the gang have so much fun Working together, they get the job done",
        "There lived a certain man in Russia long ago He was big and strong, in his eyes a flaming glow Most people look at him with terror and with fear But to Moscow chicks, he was such a lovely dear He could preach the Bible like a preacher Full of ecstasy and fire But he also was the kind of teacher Women would desire",
        "This ain't a song for the broken hearted No silent prayer for the faith departed I ain't gonna be just a face in the crowd You're gonna hear my voice when I shout it out loud",
        "Something tells me that I'm dreaming I can see us there Waving unaware Of problems that have a tendency to keep Keep the truth confined Far from our minds You need someone you can believe in This I do declare Trust me I'll be there The road that leads to heaven can be so steep I will help you climb Change your state of mind",
        "I could fill your cup You know my river won't evaporate this world we still appreciate You could be my luck Even in a hurricane of frowns I know that we'll be safe and sound",
        "No matter how hard I try You keep pushing me aside And I can't break through There's no talking to you It's so sad that you're leaving It takes time to believe it But after all is said and done You're gonna be the lonely one",
        "As I walk through the valley of the shadow of death I take a look at my life and realize there's nothing left 'Cause I've been blasting and laughing so long, that Even my momma thinks that my mind is gone But I ain't never crossed a man that didn't deserve it Me be treated like a punk, you know that's unheard of You better watch how you talking and where you walking Or you and your homies might be lined in chalk I really hate to trip, but I gotta loc As they croak, I see myself in the pistol smoke Fool, I'm the kinda G the little homies wanna be like On my knees in the night, saying prayers in the streetlight",
        "There is freedom within, there is freedom without Try to catch a deluge in a paper cup There's a battle ahead, many battles are lost But you'll never see the end of the road While you're travelling with me",
        "Like the legend of the phoenix All ends with beginnings What keeps the planet spinning The force from the beginning Look We've come too far To give up who we are So let's raise the bar And our cups to the stars",
        "I set my sights on you And no one else will do And I, I've got to have my way now, baby All I know is that to me You look like you're having fun Open up your loving arms Watch out, here I come",
        "Words like violence break the silence Come crashing in into my little world Painful to me, pierce right through me Can't you understand? Oh, my little girl All I ever wanted All I ever needed is here in my arms Words are very unnecessary They can only do harm",
        "I wake up everyday it's a daydream Everything in my life ain't what it seems I wake up just to go back to sleep I act real shallow but I'm in too deep And all I care about is sex and violence A heavy bass line is my kind of silence Everybody says that I gotta get a grip But I let sanity give me the slip",
        "X gon' give it to ya Fuck waitin' for you to get it on your own, X gon' deliver to ya Knock knock, open up the door, it's real With the nonstop pop pop from stainless steel Go hard, gettin' busy with it But I got such a good heart that I'll make a motherfucker wonder if he did it Damn right, and I'll do it again 'Cause I am light so I gots to win Break bread with the enemy No matter how many cats I break bread with, I'll break who you sendin' me You motherfuckers never wanted nothin' but your life saved Bitch, and that's on a light day",
        "He came from somewhere back in her long ago The sentimental fool don't see Trying hard to recreate What had yet to be created once in her life She musters a smile for his nostalgic tale Never coming near what he wanted to say Only to realize it never really was",
        "So now, we fly ever free, we're free before the thunderstorm On towards the wilderness, our quest carries on Far beyond the sundown, far beyond the moonlight Deep inside our hearts and all our souls",
        "Do you remember The twenty first night of September? Love was changing the minds of pretenders While chasing the clouds away Our hearts were ringing In the key that our souls were singing As we danced in the night, remember How the stars stole the night away",
        "I'm on my way Driving at ninety down those country lanes Singing to Tiny Dancer And I miss the way you make me feel, and it's real We watched the sunset over the castle on the hill",
        "I have a blue house with a blue window Blue is the color of all that I wear Blue are the streets and all the trees are too I have a girlfriend and she is so blue Blue are the people here that walk around Blue like my Corvette, it's sitting outside Blue are the words I say and what I think Blue are the feelings that live inside me",
        "The sun is shining in the sky There ain't a cloud in sight It's stopped raining, everybody's in the play And don't you know it's a beautiful new day, hey Running down the avenue See how the sun shines brightly In the city, on the streets where once was pity Mr. Blue Sky is living here today, hey",
        "I remember when rock was young Me and Susie had so much fun Holding hands and skimming stones Had an old gold Chevy and a place of my own But the biggest kick I ever got Was doing a thing called the Crocodile Rock While the other kids were rocking 'round the clock We were hopping and bopping to the Crocodile Rock",
        "Fill 'em with the venom and eliminate 'em Other words, I Minute Maid 'em I don't wanna hurt 'em, but I did, I'm in a fit of rage I'm murdering again, nobody will evade I'm finna kill 'em and dump all their fucking bodies in the lake Obliterating everything, incinerate a renegade I'm here to make anybody who want it with the pen afraid But don't nobody want it, but they're gonna get it anyway 'Cause I'm beginning to feel like I'm mentally ill I'm Attila, kill or be killed, I'm a killer bee, the vanilla gorilla You're bringing the killer within me outta me You don't wanna be the enemy of the demon who entered me And be on the receiving end of me, what stupidity it'd be Every bit of me's the epitome of a spitter When I'm in the vicinity, motherfucker, you better duck Or you finna be dead the minute you run into me A hundred percent of you is a fifth of a percent of me I'm about to fucking finish you, bitch, I'm unfadable You wanna battle, I'm available, I'm blowing up like an inflatable I'm undebatable, I'm unavoidable, I'm unevadable I'm on the toilet bowl, I got a trailer full of money and I'm paid in full",
        "No one on Earth could feel like this I'm thrown and overblown with bliss There must be an angel Playing with my heart, yeah I walk into an empty room And suddenly my heart goes boom! It's an orchestra of angels And they're playing with my heart, yeah",
        "How can you see into my eyes like open doors? Leading you down into my core, where I've become so numb",
        "I've got another confession, my friend I'm no fool I'm getting tired of starting again Somewhere new Were you born to resist Or be abused? I swear I'll never give in I refuse Is someone getting the best The best, the best, the best of you?",
        "Robert's got a quick hand He'll look around the room, he won't tell you his plan He's got a rolled cigarette Hanging out his mouth, he's a cowboy kid Yeah, he found a six shooter gun In his dad's closet with a box of fun things I don't even know what But he's coming for you, yeah, he's coming for you",
        "So if you're lonely, you know I'm here waiting for you I'm just a crosshair, I'm just a shot away from you And if you leave here, you leave me broken, shattered I lie I'm just a crosshair, I'm just a shot, then we can die",
        "And so you're back, from outer space I just walked in to find you here with that sad look upon your face I should have changed that stupid lock I should have made you leave your key If I'd have known for just one second you'd be back to bother me Go on now, go, walk out the door Just turn around now, 'cause you're not welcome anymore Weren't you the one who tried to hurt me with goodbye? Did you think I'd crumble? Did you think I'd lay down and die?",
        "Finally, someone let me out of my cage Now, time for me is nothing, 'cause I'm counting no age Nah, I couldn't be there, now you shouldn't be scared I'm good at repairs, and I'm under each snare Intangible, bet you didn't think, so I command you to Panoramic view, look, I'll make it all manageable Pick and choose, sit and lose, all you different crews Chicks and dudes, who you think is really kicking tunes?",
        "But you didn't have to cut me off Make out like it never happened and that we were nothing And I don't even need your love But you treat me like a stranger, and that feels so rough No, you didn't have to stoop so low Have your friends collect your records and then change your number I guess that I don't need that though Now you're just somebody that I used to know",
        "Pack it up, pack it in, let me begin I came to win, battle me, that's a sin I won't ever slack up, punk, ya better back up Try and play the role and yo, the whole crew'll act up Get up, stand up, come on, throw your hands up If ya got the feeling, jump up towards the ceiling Muggs lets the funk flow, someone's talking junk Yo, I bust him in the eye and then I'll take the punk's ho Feeling, funking, amps in the trunk, and I got more rhymes than there's cops at a Dunkin Donuts shop, sho' nuff, I got props From the kids on the Hill plus my mom and my pops I came to get down, I came to get down So get out your seat and jump around",
        "In the dock of Tiger Bay On the road to Mandalay From Bombay to Santa Fe Over hills and far away",
        "And I'm thinking, what a mess we're in Hard to know where to begin If I could slip the sickly ties of Earth that man has made And now every mother can choose the colour Of her child That's not nature's way Well, that's what they said yesterday There's nothin' left to do but pray I think it's time I found a new religion",
        "Almost Heaven, West Virginia Blue Ridge Mountains, Shenandoah River Life is old there, older than the trees Younger than the mountains, growing like a breeze",
        "I'm bringin' sexy back Them other boys don't know how to act I think it's special, what's behind your back? So turn around and I'll pick up the slack Take it to the bridge, c'mon Dirty babe You see these shackles, baby, I'm your slave I'll let you whip me if I misbehave It's just that no one makes me feel this way",
        "Due to lack of interest Tomorrow is cancelled Let the clocks be reset And the pendulums held 'Cause there's nothing at all Except the space in between Finding out what you're called And repeating your name",
        "Out on the wily, windy moors We'd roll and fall in green You had a temper like my jealousy Too hot, too greedy How could you leave me When I needed to possess you? I hated you, I loved you too",
        "There's something inside you It's hard to explain They're talking about you, boy But you're still the same",
        "Ladies and gentlemen, this is something They call a ground breaker So, let me first apologize to the shirts and the ties For your make up Cause I'll make you ugly, as soon as it drops We're on a rampage, bottles poppin' off Before you know it, there's rubble and dust Cause we'll be pushing it up Somebody say You better run!",
        "And this one is for the champions I ain't lost since I began, yeah Funny how you said it was the end, yeah Then I went did it again, yeah I told you long ago on the road I got what they waiting for I don't run from nothing, dog Get your soldiers, tell 'em I ain't laying low You was never really rooting for me anyway When I'm back up at the top, I wanna hear you say He don't run from nothing, dog Get your soldiers, tell 'em that the break is over",
        "It starts with one thing, I don't know why It doesn't even matter how hard you try Keep that in mind, I designed this rhyme To explain in due time all I know Time is a valuable thing Watch it fly by as the pendulum swings Watch it count down to the end of the day The clock ticks life away, it's so unreal Didn't look out below Watch the time go right out the window Trying to hold on, didn't even know I wasted it all just to watch you go I kept everything inside And even though I tried, it all fell apart What it meant to me will eventually be A memory",
        "In the club: Party rock Looking for your girl? She on my jock Nonstop when we in the spot Booty moving weight like she on the block Where the drank? I gots to know Tight jeans, tattoo, 'cause I'm rock and roll Half black, half white: domino Gaining money, Oprah, dough Yo! I'm running through these hoes like Drano I got that devilish flow, rock and roll, no halo We party rock!, yeah, that's the crew that I'm reppin' On the rise to the top, no Led in our Zeppelin",
        "Copping it, washing it, 'bout to go and get some compliments Passing up on those moccasins someone else has been walking in Bummy and grungy, fuck it man, I am stunting and flossing And saving my money and I'm hella happy; that's a bargain, bitch I'ma take your grandpa's style, I'ma take your grandpa's style No, for real, ask your grandpa, can I have his hand me downs? Velour jumpsuit and some house slippers Dookie brown leather jacket that I found digging They had a broken keyboard, I bought a broken keyboard I bought a skeet blanket, then I bought a knee board Hello, hello, my ace man, my mellow John Wayne ain't got nothing on my fringe game, hell no I could take some Pro Wings, make 'em cool, sell those The sneaker heads would be like, Ah, he got the Velcros",
        "The headmaster's had enough today All the kids have gone away Gone to fight with next door's school Every term that is the rule Sits alone and bends his cane Same old backsides again All the small ones tell tall tales Walking home and squashing snails Oh what fun we had But did it really turn out bad All i learnt at school Was how to bend not break the rules Oh what fun we had But at the time it seemed so bad Trying different ways to Make a difference to the days",
        "Davy's on the road again Wearin' different clothes again Davy's turning handouts down To keep his pockets clean Sayin' his goodbyes again Wheels are in his eyes again Says, If you see Jean, now Ask her, please, to pity me",
        "This hit, that ice cold Michelle Pfeiffer, that white gold This one for them hood girls Them good girls, straight masterpieces Stylin', wilin', living it up in the city Got Chucks on with Saint Laurent Gotta kiss myself, I'm so pretty",
        "Maybe it's hard, when you feel like You're broken and scarred, nothing feels right But when you're with me I'll make you believe That I've got the key Oh, so get in the car, we can ride it Wherever you want, get inside it And you wanna steer, but I'm shifting gears I'll take it from here",
        "Buying bread from a man in Brussels He was six foot four and full of muscle I said, Do you speaka my language? And he just smiled and gave me a vegemite sandwich And he said I come from a land down under Where beer does flow and men chunder Can't you hear, can't you hear the thunder? You better run, you better take cover",
        "Picking through the cards, knowing what's nearby The carvings on the face say they find it hard And the engine's failed again, all limits of disguise The humor's not the same, coming from denial",
        "It's close to midnight And something evil's lurking in the dark Under the moonlight You see a sight that almost stops your heart You try to scream But terror takes the sound before you make it You start to freeze As horror looks you right between the eyes You're paralyzed",
        "Just a steel town girl on a Saturday night Looking for the fight of her life In the real time world, no one sees her at all They all say she's crazy Locking rhythms to the beat of her heart Changing movement into light She has danced into the danger zone When the dancer becomes the dance",
        "And I want you We can bring it on the floor You've never danced like this before We don't talk about it Dancing on, do the boogie all night long You're stoned in paradise Shouldn't talk about it",
        "Interchanging mind control Come let the revolution take its toll If you could flick a switch and open your third eye You'd see that we should never be afraid to die Rise up and take the power back It's time the fat cats had a heart attack You know that their time's coming to an end We have to unify and watch our flag ascend",
        "Sometimes, I get the feeling she's watching over me And other times, I feel like I should go And through it all, the rise and fall, the bodies in the streets And when you're gone, we want you all to know We'll carry on, we'll carry on And though you're dead and gone, believe me Your memory will carry on, we'll carry on And in my heart, I can't contain it The anthem won't explain it",
        "Staring at the blank page before you Open up the dirty window Let the sun illuminate the words that you cannot find Reaching for something in the distance So close you can almost taste it Release your inhibitions",
        "I see a ship in the harbour I can and shall obey But, if it wasn't for your misfortune I'd be a heavenly person today And I thought I was mistaken And I thought I heard you speak Tell me, how do I feel? Tell me now, how should I feel? Now I stand here waiting",
        "Near a tree by a river, there's a hole in the ground Where an old man of Aran goes around and around And his mind is a beacon in the veil of the night For a strange kind of fashion, there's a wrong and a right But he'll never, never fight over you",
        "Load up on guns, bring your friends It's fun to lose and to pretend She's over bored and self assured Oh no, I know a dirty word",
        "I left my home in Georgia Headed for the 'Frisco bay 'Cause I've had nothing to live for And look like nothing's gonna come my way So I'm just gonna sit on the dock of the bay Watching the tide roll away I'm sitting on the dock of the bay Wasting time",
        "My baby don't mess around Because she loves me so, and this I know for sure But does she really wanna But can't stand to see me walk out the door? Don't try to fight the feeling 'Cause the thought alone is killing me right now Thank God for Mom and Dad For sticking two together 'cause we don't know how",
        "Alo! Salut! Sunt eu, un haiduc! Și te rog, iubirea mea Primește fericirea Alo! Alo! Sunt eu, Picasso! Țiam dat beep, și sunt voinic Dar să știi, nuți cer nimic",
        "Rent a flat above a shop And cut your hair and get a job And smoke some fags and play some pool Pretend you never went to school But still you'll never get it right 'Cause when you're laid in bed at night Watching roaches climb the wall If you called your dad he could stop it all",
        "Party people in the house, lets go It's your boy Jay Ski, aight So pass that thing and watch me flex Behind my back, you know what's next To the jam, all in your face Wassup, just feel the bass Drop it, rock it, down the room Shake it, quake it, space; kaboom Just work that body, work that body Make sure you don't hurt nobody Get wild and lose your mind Take this thing into overtime Hey DJ, turn it up QCD gon' burn it up C'mon, y'all get on the floor So hey, let's go aight",
        "I'm a rocket ship on my way to Mars on a collision course I am a satellite, I'm out of control I'm a sex machine, ready to reload like an atom bomb About to oh, oh, oh, oh, oh, explode I'm burning through the sky, yeah Two hundred degrees, that's why they call me Mister Fahrenheit I'm travelling at the speed of light I wanna make a supersonic woman of you",
        "We're no strangers to love You know the rules and so do I A full commitment's what I'm thinking of You wouldn't get this from any other guy I just wanna tell you how I'm feeling Gotta make you understand",
        "She's into new sensations New kicks in the candlelight She's got a new addiction For every day and night She'll make you take your clothes off and go dancing in the rain She'll make you live her crazy life, but she'll take away your pain Like a bullet to your brain",
        "Man, it's a hot one Like seven inches from the midday sun I hear you whisper and the words melt everyone But you stay so cool My munequita, my Spanish Harlem Mona Lisa You're my reason for reason, the step in my groove",
        "Everybody's talking something very shocking Just to keep on blocking what they're feeling inside But listen to me, brother, you just keep on walking 'Cause you and me and sister ain't got nothing to hide Scatman, fat man, black and white and brown man Tell me about the color of your soul If part of your solution isn't ending the pollution Then I don't want to hear your stories told I want to welcome you to Scatman's World",
        "Somebody once told me the world is gonna roll me I ain't the sharpest tool in the shed She was looking kind of dumb with her finger and her thumb In the shape of an L on her forehead",
        "Sometimes I feel I've got to Run away I've got to Get away From the pain you drive into the heart of me The love we share Seems to go nowhere And I've lost my light For I toss and turn I can't sleep at night",
        "In my eyes, indisposed In disguises no one knows Hides the face, lies the snake In the sun in my disgrace Boiling heat, summer stench 'Neath the black, the sky looks dead Call my name through the cream And I'll hear you scream again",
        "Rising up, back on the street Did my time, took my chances Went the distance, now I'm back on my feet Just a man and his will to survive So many times, it happens too fast You trade your passion for glory Don't lose your grip on the dreams of the past You must fight just to keep them alive",
        "Do you hear the flibbity jibbity jibber jabber With an, Oh my god I've got to get out of here or I'll have another Word to sell, another story to tell Another timepiece ringing the bell? Do you hear the clock stop when you reach the end? No, you know it must be neverending, comprehend if you can But when you try to pretend to understand You resemble a fool, although you're only a man So give it up and smile",
        "Someone said they left together I ran out the door to get her She was holding hands with Trevor Not the greatest feeling ever Said, Pull yourself together You should try your luck with Heather Then I heard they slept together Oh, the less I know the better",
        "Welcome to your life There's no turning back Even while we sleep We will find you Acting on your best behaviour Turn your back on Mother Nature Everybody wants to rule the world",
        "And the peculiar thing is this, my friends The song we sang on that fateful night It didn't actually sound anything like this song This is just a tribute You've got to believe me And I wish you were there Just a matter of opinion Ah, fuck! Good God, gotta love it now So surprised to find you can't stop it now A fiery ring of fire Rich motherfucker",
        "Well, I'm so above you and it's plain to see But I came to love you anyway So you pulled my heart out and I don't mind bleeding Any old time you keep me waiting Waiting, waiting",
        "I don't care if Monday's blue Tuesday's grey and Wednesday too Thursday, I don't care about you It's Friday, I'm in love Monday, you can fall apart Tuesday, Wednesday, break my heart Thursday doesn't even start It's Friday, I'm in love",
        "Can't explain all the feelings that you're making me feel My heart's in overdrive and you're behind the steering wheel Touching you Touching me Touching you, God, you're touching me",
        "Some sort of window to your right As he goes left and you stay right Between the lines of fear and blame You begin to wonder why you came",
        "Goodbye, Mr. A You promised you would love us, but you knew too much Goodbye, Mr. A You had all the answers, but no human touch If life is subtraction, your number is up Your love is a fraction, it's not adding up",
        "Coming out of my cage and I've been doing just fine Gotta, gotta be down because I want it all It started out with a kiss, how did it end up like this? It was only a kiss, it was only a kiss Now I'm falling asleep and she's calling a cab While he's having a smoke and she's taking a drag Now they're going to bed, and my stomach is sick And it's all in my head",
        "You know, it's kinda hard just to get along today Our subject isn't cool, but he fakes it anyway He may not have a clue and he may not have style But everything he lacks, well, he makes up in denial So don't debate, a player straight You know he really doesn't get it anyway Gotta play the field, and keep it real For you no way, for you no way So if you don't rate, just overcompensate At least that you'll know you can always go on Ricki Lake The world needs wannabes, ah Hey, hey, do that brand new thing!",
        "House so empty, need a centerpiece Twenty racks a table, cut from ebony Cut that ivory into skinny pieces Then she clean it with her face, man, I love my baby You talking money, need a hearing aid You talking about me, I don't see the shade Switch up my style, I take any lane I switch up my cup, I kill any pain",
        "I'm gonna fight 'em off A seven nation army couldn't hold me back They're gonna rip it off Taking their time right behind my back And I'm talking to myself at night Because I can't forget Back and forth through my mind Behind a cigarette",
        "It's gonna take the lot to drag me away from you There's nothing that a hundred men or more could ever do I bless the rains down in Africa Gonna take some time to do the things we never had",
        "Ocean man, can you see through the wonder of amazement At the Oberman? Ocean man, the crust is elusive when it casts forth To the childlike man Ocean man, the sequence of a life form braised in the sand Soaking up the thirst of the land",
        "They've got Allen wrenches, gerbil feeders, toilet seats, electric heaters Trash compactors, juice extractors, shower rods and water meters Walkie talkies, copper wires, safety goggles, radial tires BB pellets, rubber mallets, fans and dehumidifiers Picture hangers, paper cutters, waffle irons, window shutters Paint removers, window louvers, masking tape and plastic gutters Kitchen faucets, folding tables, weather stripping, jumper cables Hooks and tackle, grout and spackle, power foggers, spoons and ladles Pesticides for fumigation, high performance lubrication Metal roofing, waterproofing, multi purpose insulation Air compressors, brass connectors, wrecking chisels, smoke detectors Tire gauges, hamster cages, thermostats and bug deflectors Trailer hitch demagnetizers, automatic circumcisers Tennis rackets, angle brackets, Duracells and Energizers Soffit panels, circuit breakers, vacuum cleaners, coffee makers Calculators, generators, matching salt and pepper shakers",
        "And her boyfriend's a dick And he brings a gun to school And he'd simply kick My ass if he knew the truth He lives on my block And he drives an IROC But he doesn't know who I am And he doesn't give a damn about me",
        "Now first it wasn't easy Changing rock and roll and minds Yeah, things were getting shaky I thought I'd have to leave it behind But now it's so much better, it's so much better I'm funking out in every way But I'll never lose that feeling, no, I won't Of how I learned my lesson that day",
        "Wild Wild West Jim West, desperado Rough rider, no you don't want nada None of this, six gunning this, brother runnin this Buffalo soldier, look it's like I told ya Any damsel that's in distress Be outta that dress when she meet Jim West Rough neck so go check the law and abide Watch your step or flex and get a hole in your side Swallow your pride, don't let your lip react You don't wanna see my hand where my hip be at With Artemus, from the start of this, running the game James West, taming the West, so remember the name",
        "In and around the lake Mountains come out of the sky and they stand there One mile over we'll be there and we'll see you Ten true summers we'll be there and laughing too Twenty four before my love you'll see I'll be there with you"
    };
    private string[] keyletters = new string[] { "a", "B", "C", "D", "E", "f", "G", "H", "i", "J", "K", "L", "M", "N", "o", "P", "Q", "R", "S", "T", "u", "V", "W", "x", "Y", "Z" };
    private string ciphkey;
    private KMAudio.KMAudioRef snippet;
    private IEnumerator play;
    private string[] choose = new string[3];
    private int songselect;
    private int state;
    private string submission = "";
    private static int moduleIDCounter;
    private int moduleID;
    private bool moduleSolved;

    private void Start()
    {
        moduleID = ++moduleIDCounter;
        foreach (GameObject k in keyobjs)
            k.SetActive(false);
        bgs[1].SetActive(false);
        songselect = UnityEngine.Random.Range(0, 100);        
        string[] songlyrics = Regex.Replace(lyrics[songselect].ToUpperInvariant(), "[^A-Z -]", "").Split(' ');
        int lselect = UnityEngine.Random.Range(0, songlyrics.Length - 2);
        while (songlyrics[lselect + 1].Length < 3 || songlyrics[lselect + 1] == "THE")
            lselect = UnityEngine.Random.Range(0, songlyrics.Length - 2);
        choose = songlyrics.Skip(lselect).Take(3).ToArray();
        ciphkey = string.Join("", keyletters.Shuffle().ToArray());
        for (int i = 0; i < 3; i++)
        {
            displays[i].text = string.Join("", choose[i].Select(x => ciphkey[x - 'A'].ToString()).ToArray());
            displays[i].fontSize = 300 - (12 * choose[i].Length);
        }
        Debug.LogFormat("[xobekuJ ehT #{0}] {1} :era sciryl deyalpsid ehT", moduleID, new string(string.Join(", ", displays.Select(x => x.text).ToArray()).ToUpperInvariant().Reverse().ToArray()));
        Debug.LogFormat("[xobekuJ ehT #{0}] {1} si gnos detceles ehT", moduleID, new string(titles[songselect].Reverse().ToArray()));
        Debug.LogFormat("[xobekuJ ehT #{0}] {1} :era sciryl detpyrced ehT", moduleID, new string(string.Join(", ", choose).Reverse().ToArray()));
        record.OnInteract = delegate ()
        {
            if (!moduleSolved)
            {
                switch (state) {
                    case 0:
                        Audio.PlaySoundAtTransform("Scratch", record.transform);
                        play = Play(samples[songselect]);
                        StartCoroutine(play);
                        break;
                    case 2:
                        StopCoroutine(play);
                        snippet.StopSound();
                        state++;
                        StartCoroutine(KeySet(true));
                        break;
                    case 4:
                        if (submission.Length > 0)
                        {
                            if (submission.Length < choose[1].Length)
                            {
                                record.AddInteractionPunch(0.6f);
                                Audio.PlaySoundAtTransform("Stop", record.transform);
                                submission = "";
                                displays[1].text = "";
                                for (int i = 0; i < choose[1].Length; i++)
                                    displays[1].text += "?";
                            }
                            else
                            {
                                state++;
                                StartCoroutine(KeySet(false));
                                submission = submission.ToUpperInvariant();
                                Debug.LogFormat("[xobekuJ ehT #{0}] {1} dettimbuS", moduleID, new string(submission.Reverse().ToArray()));
                                if (submission == choose[1])
                                {
                                    moduleSolved = true;
                                    module.HandlePass();
                                    record.AddInteractionPunch(0.6f);
                                    Audio.PlaySoundAtTransform("Victory", record.transform);
                                }
                                else
                                {
                                    submission = "";
                                    module.HandleStrike();
                                    record.AddInteractionPunch(0.6f);
                                    Audio.PlaySoundAtTransform("Smash", record.transform);
                                }
                            }
                        }
                        break;
                }
            }
            return false;
        };
        foreach(KMSelectable key in keys)
        {
            int b = keys.IndexOf(key);
            key.OnInteract = delegate ()
            {
                if (!moduleSolved && submission.Length < choose[1].Length)
                {
                    Audio.PlaySoundAtTransform("KeyPress", key.transform);
                    key.AddInteractionPunch(0.2f);
                    submission = keyletters[b] + submission;
                    displays[1].text = "";
                    for (int i = submission.Length; i < choose[1].Length; i++)
                        displays[1].text += "?";
                    displays[1].text += submission;
                }
                return false;
            };
        }
    }

    private IEnumerator Play(AudioClip song)
    {
        state++;
        for (int i = 0; i < 3; i++)
            displays[i].text = "";
        bgs[0].SetActive(false);
        float e = 0;
        while(e < 1.5f)
        {
            float d = Time.deltaTime;
            e += d;
            bgs[2].transform.Rotate(0, -360 * d / 1.5f, 0);
            yield return null;
        }
        bgs[1].SetActive(true);
        StartCoroutine("RingOut");
        snippet = Audio.PlaySoundAtTransformWithRef(song.name, transform);
        state++;
        e = 0;
        while(e < song.length)
        {
            float d = Time.deltaTime;
            e += d;
            bgs[2].transform.Rotate(0, 360 * d / song.length, 0);
            yield return null;
        }
        bgs[2].transform.localRotation = Quaternion.Euler(0, 0, 0);
        snippet.StopSound();
        state++;
        StartCoroutine(KeySet(true));
    }

    private IEnumerator RingOut()
    {
        while (!moduleSolved)
        {
            for(int i = 0; i < 4; i++)
            {
                soundwave.material = wavemats[i];
                yield return new WaitForSeconds(0.125f);
            }
        }
    }

    private IEnumerator KeySet(bool on)
    {
        StopCoroutine("RingOut");
        bgs[0].SetActive(true);
        bgs[1].SetActive(false);
        float x = bgs[2].transform.localEulerAngles.y;
        if (x != 0)
        {
            Audio.PlaySoundAtTransform("Stop", transform);
            float e = 0;
            while (e < 0.7f)
            {
                float d = Time.deltaTime;
                e += d;
                bgs[2].transform.Rotate(0, (360 - x) * d / 0.7f, 0);
                yield return null;
            }
            bgs[2].transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        keyletters = keyletters.Shuffle();
        for (int i = 0; i < 26; i++)
            keylabels[i].text = keyletters[i];
        for (int i = 0; i < 13; i++)
        {
            keyobjs[on ? i : 12 - i].SetActive(on);
            keyobjs[on ? i + 13 : 25 - i].SetActive(on);
            Audio.PlaySoundAtTransform("KeyPress", transform);
            yield return new WaitForSeconds(0.032f);
        }
        if (on)
        {
            state++;
            for (int i = 0; i < choose[1].Length; i++)
                displays[1].text += "?";
        }
        else
        {
            if (moduleSolved)
                for (int i = 0; i < 3; i++)
                    displays[i].text = choose[i];
            else
            {
                state = 0;
                for (int i = 0; i < 3; i++)
                    displays[i].text = string.Join("", choose[i].Select(k => ciphkey[k - 'A'].ToString()).ToArray());
            }
        }
    }

    //twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} drocer [drocer eht sesserP] | !{0} <srettel> sserp [srettel deificeps eht htiw syek eht sesserP]";
    #pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
        if (Regex.IsMatch(command, @"^\s*drocer\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            if (state == 0 || state == 2 || state == 4)
            {
                yield return null;
                record.OnInteract();
            }
            else
                yield return "sendtochaterror !won thgir desserp eb tonnac drocer ehT";
            yield break;
        }
        string[] keysLowered = keyletters.ToArray();
        for (int i = 0; i < keysLowered.Length; i++)
            keysLowered[i] = keysLowered[i].ToLowerInvariant();
        string[] parameters = command.Reverse().Join("").ToLowerInvariant().Split(' ');
        if (parameters[0].Equals("press"))
        {
            if (parameters.Length > 2)
            {
                yield return "sendtochaterror !sretemarap ynam ooT";
                yield break;
            }
            else if (parameters.Length == 1)
            {
                yield return "sendtochaterror !retne ot hsiw uoy srettel eht yficeps esaelP";
                yield break;
            }
            else
            {
                for (int i = 0; i < parameters[1].Length; i++)
                {
                    if (!keysLowered.Contains(parameters[1][i].ToString()))
                    {
                        yield return "sendtochaterror!f !rettel a ton si \"" + parameters[1][i] + "\"";
                        yield break;
                    }
                }
                if (state == 1 || state == 3)
                {
                    yield return "sendtochaterror !won thgir srettel yna retne tonnac uoY";
                    yield break;
                }
                yield return null;
                for (int i = 0; i < parameters[1].Length; i++)
                {
                    if (submission.Length == choose[1].Length)
                        break;
                    keys[Array.IndexOf(keysLowered, parameters[1][i].ToString())].OnInteract();
                    yield return new WaitForSeconds(.1f);
                }
            }
        }
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        while (true)
        {
            if (state % 2 == 0)
            {
                if (state == 4)
                    break;
                else
                    record.OnInteract();
            }
            else
                yield return true;
        }
        if (submission.Length == choose[1].Length && submission.ToUpperInvariant() != choose[1])
        {
            moduleSolved = true;
            module.HandlePass();
            yield break;
        }
        if (submission.Length != choose[1].Length)
        {
            string upperSub = submission.ToUpperInvariant();
            for (int i = 0; i < upperSub.Length; i++)
            {
                if (upperSub[upperSub.Length - 1 - i] != choose[1][choose[1].Length - 1 - i])
                {
                    record.OnInteract();
                    yield return new WaitForSeconds(.1f);
                    break;
                }
            }
        }
        string[] upperKeys = keyletters.ToArray();
        for (int i = 0; i < upperKeys.Length; i++)
            upperKeys[i] = upperKeys[i].ToUpperInvariant();
        string reversed = choose[1].Reverse().Join("");
        int start = submission.Length;
        for (int i = start; i < reversed.Length; i++)
        {
            keys[Array.IndexOf(upperKeys, reversed[i].ToString())].OnInteract();
            yield return new WaitForSeconds(.1f);
        }
        record.OnInteract();
    }
}
