**[Unrelated to the interview]

**[00:10] coolcamilla:** First, let’s talk about this week’s goal, which was to add some mechanics we came up with a long time ago. So, it turns out, the stations…
**[00:20] Customer:** Seedlings?
**[00:21] coolcamilla:** We didn’t remove the seedlings; they’re still there. 
**[00:23] Customer:** Thanks.
**[00:21] coolcamilla:** It’s the transition between layers and the logic of the mining station. And also what you suggested. Right now, you can buy beer with coins, and if your stamina runs out, the mole dies.
**[00:35] Customer:** Great.
**[00:36] coolcamilla:** And beer increases your stamina. 
**[00:41] Customer:** Permanently? 
**[00:42] coolcamilla:** Yes, permanently.
**[00:43] Customer:** Just like in real life. 
**[00:42] coolcamilla:** Yes. We also changed... Well, digging is more fun now. There are animations and particles. And we’ve also prepared the handover documentation. It explains how we’ll hand the project over to you. Now... Oh, I can also show you the Sprint Backlog if you’re interested.
**[01:11] Customer:** Okay, yeah, our favorite. Let’s take a look at the Sprint Backlog. Did you design the interface?
**[01:25] coolcamilla:** We sketched it out-just a rough draft, really-but we haven’t added it yet. Next week, we’ll be making mostly cosmetic tweaks to ensure everything looks consistently polished.
**[02:02] Customer:** Hit sounds. What’s the game designer working on right now?
**[02:05] WazzuRunaway:** Hit sounds. 
**[02:06] Customer:** And game design?
**[02:11] WazzuRunaway:** Well, all the mechanics are actually done. He’s on vacation. He seems really fired up right now. I’ve been in touch with him and met up with him. 
**[02:24] Customer:** That’s amazing. It only took three weeks to get a kick out of **[inaudible]. **[02:31] coolcamilla:** We’re slowly implementing what he came up with in the first two weeks.
**[02:41] Customer:** Man, you guys explain things so well-I like it.
**[02:44] coolcamilla:** Thanks. Now SunrisEe41 will take it from here. 
**[02:51] SunrisEe41:** We have customer handover documents where we outline what we actually have right now. These aren’t just our dreams anymore, or some “we plan to do this in the future”-they’re things we’ve actually implemented and achieved. And it’s all in a convenient Markdown format.
**[03:16] Customer:** That’s the most important part. I’ll read it now. 
**[03:51] Customer:** Okay, so where’s the folder with the actual project? Or is there just a clean build? 
**[03:58] SunrisEe41:** The folder with the actual project is in the source code on the repository.

**[Unrelated to the interview]

**[06:52] SunrisEe41:** We also need to talk about what our plans were. One option is to upload it to itch.io.

**[06:59] Customer:** Yes. We’d like you to actually deploy the build to some platform: either to the web, or there, or to itch.io. 
**[07:08] coolcamilla:** It’s just that for our assignment, we’re being asked if we’re going to deploy the game somehow. And we thought we could upload it to itch.io-definitely not on Steam. 
**[07:20] Customer:** Definitely not. The bigger question here is: where on the web? First, we need to create a web build and see how it works… Of course, you can release on itch.io without a web version, but having a web version means greater reach, and you can distribute it to other platforms. And make some money on the side! At the very least, it would be a great experience if you could get it to a platform that actually pays out. Well, itch.io for sure.
**[08:12] Customer:** Now look, if you don’t plan on finishing the project yourself, you can basically hand it over along with the Git repository. Of course, I can’t say I’ll ever find a team for it-maybe I will-but usually the people who come along want to work on something of their own right away.

**[Unrelated to the interview]

**[09:15] Customer:** But the main thing is that you actually upload it to itch.io. Or, at best, have it available on various web platforms. I mean, not just Yandex-there’s a mix of them. If something comes your way, you’ll already have something to fall back on.
**[09:36] SunrisEe41:** There’s also “Contributing”-it’s a guide on how our workflow is set up and how to continue the project.
**[09:45] Customer:** Cool, it’s all written up really well. Did you write it yourself, or was it AI?
**[09:51] SunrisEe41:** AI plus some edits, as usual.
**[09:56] Customer:** Yeah, the structure is very cohesive. That’s it. I genuinely trust that everything here is in order. There’s a lot of hassle with this documentation, but thankfully, AI really speeds things up, of course. I used to write all of this by hand back in the day. 

### UAT session begins

**[12:03] Customer:** The most important thing is that the “Settings” menu works. Right? 
**[12:08] WazzuRunaway:** No, it’s still not bold. 
**[12:17] coolcamilla:** First you have to follow the instructions a little bit, then you can do whatever you want. Actually, we kind of need to save up 5 coins… 
**[12:34] Customer:** What’s the catch?
**[12:35] WazzuRunaway:** They’re rare-very rare.
**[12:40] coolcamilla:** Well, basically, as you’re tinkering around, you’ll accumulate them eventually; we’ll check that separately.
**[12:45] Customer:** Wow! Sure, the particles should be scaled back, but overall it’s already good. It’s already good compared to what it was. It already has a feel to it.
**[13:05] coolcamilla:** Okay, right now-again, while you still have a few resources left and it’s okay to die-press C. And die in climbing mode. Just crawl around for now… The mole died. 
**[13:30] Customer:** Too bad. I think he’s still alive-he was lying there and breathing. (jokingly) 
**[13:35] coolcamilla:** And now check your inventory. There’s nothing left. 
**[13:40] Customer:** Cool. Just like in real life.
**[13:43] coolcamilla:** The only thing is, when you die, you keep all the coins you’ve collected, and your tools stay with you too. Well, so it’s not too brutal. 
**[13:53] Customer:** Where’s the button to hit? Not with the mouse. Why does the mouse still exist? 
**[14:05] coolcamilla:** We’ll keep that in mind-we’ll fix it next week. We already have an issue open for that. Next up are the mining stations. You can dig up clay right now.
**[14:41] Customer:** Does stamina regenerate here too (as usual)? Man, can you make a recovery station?
**[14:53] SunrisEe41:** Like, can you only regenerate in one spot?
**[14:58] Customer:** Yeah. Sure, you could make something you can place somewhere or buy, so you don’t have to put it in certain parts of the location, but overall, yeah. 
**[15:08] coolcamilla:** Can you dig all the way through this square? 
**[15:12] Customer:** And the stamina should be lower. And it could gradually deplete while walking, to make it fairer. So our favorite 5x5 room. 
**[15:08] coolcamilla:** No, no, no. Like this square here that’s buried. See? Go to it in Climbing Mode.
**[15:35] Customer:** Cool.
**[15:38] coolcamilla:** You don’t have enough resources; collect 8 sticks and 5 stones.
**[16:07] Customer:**  Man, please make the model smaller.
**[16:09] coolcamilla:** The mole? 
**[16:10] Customer:** Well, while it’s crawling, so she doesn’t get knocked out.
**[16:21] Customer:** Okay, so what do we have here? 
**[16:26] SunrisEe41:** And it’ll just keep spilling, spilling, spilling. 
**[16:27] coolcamilla:** Yeah, and it kind of spills clay every now and then. 
**[16:29] Customer:** Clay, right? He’s mixing it. Cool. 
**[16:32] coolcamilla:** And there’ll also be some for coal and copper. 
**[16:42] SunrisEe41:** If you don’t go near her for a long time, there’ll be a big pile of it lying there.
**[16:48] Customer:** I get it. Let’s not go near her-let’s dig a hole right now; this spot is perfect.
**[16:57] coolcamilla:** Alright, okay, now the next step is to go to the drill. 
**[17:02] Customer:** Let’s go to the drill. Wait, where did the money come from? Oh no. (The mole died)
**[17:11] SunrisEe41:** That’s classic retro horror.
**[17:13] Customer:** We should warn players when their stamina is running out. 
**[17:15] coolcamilla:** Okay. Phil. You’re out of stamina. 
**[17:30] Customer:** That’s actually really sad. Can’t I walk up to my corpse and pick it up?
**[17:48] coolcamilla:** Not yet. Well, should we even add that at all? 
**[17:50] Customer:** Just a little backpack would do. 
**[17:53] WazzuRunaway:** At least let us keep half our resources. 
**[18:02] coolcamilla:** Well, there’s not much new to show with the drill yet. Basically, we just need to start it up now so it can dig down to a new layer in the background. How long does it take to dig, roughly? 
**[18:20] SunrisEe41:** Without upgrades, it takes seven and a half minutes.
**[18:24] WazzuRunaway:** Well, around that, I guess. 
**[18:25] SunrisEe41:** With upgrades, it’s three.
**[18:26] Customer:** What about the FPS? 
**[18:30] SunrisEe41:** It’s overheating.
**[18:37] Customer:** From the mole game?
**[18:39] SunrisEe41:** I don’t know, something’s wrong with my laptop... 
**[18:41] Customer:** Did I go somewhere I shouldn’t have? Okay, we won’t go there.
**[18:51] SunrisEe41:** No, it’ll probably go away soon… I didn’t think about that-I mean, these things happen.
**[19:00] Customer:** Man, that was awesome-you really played up the nostalgia. I used to play all kinds of games with the same FPS all the time when I was a kid. 
**[19:12] coolcamilla:** It’s actually a new mechanic.
**[19:21] Customer:** Very interesting. Okay, I need another 2 minutes. Will the price go up with each beer?
**[19:27] coolcamilla:** No. 
**[19:28] WazzuRunaway:** Not yet. 
**[19:35] SunrisEe41:** We need beer scaling. Each new beer is harder to drink. 
**[19:42] coolcamilla:** On the contrary, it’s easier to drink.
**[19:47] Customer:** What’s the status on the backgrounds? 
**[19:52] coolcamilla:** Like the general ones?
**[19:54] Customer:** Yes. And this part here. So the world feels like a world-otherwise, you only have a week left, and you have to draw all of this. 
**[20:10] SunrisEe41:** Overall, I think we just have this background and the wall left to finish. 
**[20:19] Customer:** And the blocks with coins.
**[20:21] coolcamilla:** We already have coins. 
**[20:24] SunrisEe41:** Blocks that look exactly like ore. 
**[20:28] coolcamilla:** Will we have those? Well, generally speaking, what do we have-at least for next week so far… here’s a question: do we even need a save feature? It doesn’t seem like there’s much to save right now. 
**[20:53] Customer:** Is it possible to add that? Without too much trouble. Question for the programmer. If it can be done quickly, then it’s better to do it. The main thing is that there’s some kind of overarching goal.
Think about it this week 
**[21:08] WazzuRunaway:** I have an idea that he was just building some kind of house out of a bunch of resources, for now, for the demo.
**[21:14] Customer:** It doesn’t have to be a house; it could be, say, making it all the way to the bottom…
**[21:17] coolcamilla:** But that was our goal, right? Like, to get to the bottom…
**[21:19] Customer:** We just need to somehow indicate that he makes it all the way to the bottom and that’s where it ends. I mean, it’s just a little game, but there should be something resembling an ending.
**[21:27] coolcamilla:** Yeah, okay. 
**[21:28] WazzuRunaway:** It’s just that he ends up with a lot of resources at the end, and I’m not sure what to do with them.
**[21:35] SunrisEe41:** Now here’s the question: how bad would it be if the save file were just a local file-let’s say, hypothetically, a .txt file-that the user could, of course, access…
**[21:45] Customer:** Well, okay. 
**[21:46] SunrisEe41:** …And it would just contain the information. 
**[21:47] Customer:** The main thing is that there’s at least something there. If they hack it, well, they’ll hack it-fine. 
**[21:56] coolcamilla:** In short, regarding... 
**[21:57] Customer:** We need to **[Inaudible] here too, then.
**[21:59] coolcamilla:** Yeah, that’s there. We just didn’t have time to get to it this week, so we postponed it. Well, we also have this other thing… So, what needs to be done? Basically, change the drill’s user interface so it’s laid out neater and looks better. Then make it so you can open everything with the mouse. You know, like when you just hover over it instead of clicking. There’s also, sort of… Well, basically, making the world loop. I mean, so that if you go to the right, you come back to the left, so to speak. And then, of course, we won’t need those white walls anymore. That’s it-we’ll get rid of them. Then… . 
**[22:42] Customer:** Rebalance the stamina-set it to this much so it levels up nicely for coins. 
**[22:49] coolcamilla:** And there’s also the key remapping left to do. So that’s pretty much it. As for improvements to the mole, I don’t think we’ll have time for that anymore. 
**[23:01] Customer:** Sure thing. Okay, I get the general idea. Can you just describe what happens when beer is purchased? I mean, does the bar itself increase somehow?
**[23:29] coolcamilla:** Well, yeah, it’s just kind of added there... 
**[23:34] Customer:** Make them into cells-maybe small cells. When you buy it, you should really be able to feel it. Take a look at how it’s done in similar products. Will the drill be presented properly?
**[23:48] coolcamilla:**  In that sense, well, as I see it, we’ll go with having this sign here, and when you walk up to it, you just see it drilling. I mean, there’s not much else to it. 
**[23:57] Customer:** Well, spruce up the interface too. Have the game designer sketch out how to make the interface look good and then pass it on… 
**[24:03] SunrisEe41:** Right now,  actually, I had a little idea. 
**[24:06] Customer:** You could just display a pop-up letter. You don’t have any damn subgroups, for crying out loud. 
**[24:30] SunrisEe41:** It’s kind of… like a mockup.
**[24:32] Customer:** Yeah. Sure, it’s a GPT mockup, but it’s good. Well, it’s okay. 
**[24:38] SunrisEe41:** The idea is to combine these upgrades so they aren’t separate cards.
**[24:40] Customer:** Yeah, yeah, yeah, go ahead. Okay. 
**[24:44] SunrisEe41:** Can we keep the background the same? Like, with the drill and... 
**[24:48] Customer:** You’re short on time, so let’s just leave it. 
**[24:50] coolcamilla:** Alright, well then, that’s it for that. Well, maybe he’ll just take a little break now. Ah, there we go. Turn the recording back on then. All right, we’re good to go again. 
**[25:32] Customer:** Well, that’s cool. 
**[25:34] coolcamilla:** Do you like digging?
**[25:36] Customer:** Yeah
**[25:50] coolcamilla:** I guess we still need to make better use of the clay somehow, otherwise it just falls, but it’s not needed anywhere else
**[25:57] SunrisEe41:** I think you just need to add more upgrades to the drill, because right now, like, you’ve only leveled it up once 
**[26:04] coolcamilla:** We should send MarikSH over to figure this out 
**[26:08] WazzuRunaway:** The idea was that clay would be something valuable, but it just turned out to be…
**[26:10] coolcamilla:** And in the end, you just have a ton of it… But isn’t it so that coins spawn more often at the top?
**[26:34] WazzuRunaway:** They do drop more often from grass, from coal, and from stones. 
**[26:59] SunrisEe41:** By the way, right now, I think-well, it’s not hard to rebalance stamina to make there be less of it-but for now, if you spam C-C-C-C-C, you kind of get out of it without spending stamina. 
**[27:11] coolcamilla:** Well, that’s not a bug-it’s a feature. You have to figure that out. Oh-oh. 
**[27:16] Customer:** Okay, cool, that’s it-I can test it now. 
**[27:59] coolcamilla:** The rocks only drop when the drill reaches them. Well, we could add some fuel for now so it keeps drilling and drilling and drilling, and then we can show it. Like, in the background, in that sense… though that’ll probably take a while. Okay, so now you’re discussing it. 

### UAT session ends

### Transition-Readiness Meeting starts

**[28:24] SunrisEe41:** We’re basically having two meetings in one. We have an issue we’ve already discussed a bit: the project’s readiness for handover. We need to ask questions like this. Well, is the product ready right now to be fully handed over to you, the client-to be transferred to you absolutely right this moment? 
**[28:49] Customer:** Not yet. 
**[28:51] SunrisEe41:** What else needs to be changed to make it ready? 
**[28:58] Customer:** Again, as we discussed, give the player a clear goal so it’s clear what’s being done and why. And polish up the base. Well, not just the base-everything we’ve gone through so far-just prioritize the most important things.
**[29:21] coolcamilla:** Here’s another question about the goal. I mean, is this at the beginning… Well, hypothetically speaking, just add that when they reach the bottom, a screen pops up saying something like, “You’ve completed the game?” Or is this still at the beginning, so that somehow… Well, hypothetically speaking, you could just add a screen there with text-like a backstory-to get to the core of it. 
**[29:43] Customer:** Well, at least we could do it that way. At least that way, and plus, well, we still need to tweak the visuals a bit so everything feels cohesive, otherwise it seems like… I don’t know what. Here, we could just highlight the buttons. Well, just the F button. 
**[29:59] coolcamilla:** Yeah, yeah, yeah, that’s right. 
**[30:01] Customer:** No fonts, and overall, we could ditch the text in favor of icons if you’re going to put it on itch, and most importantly-the digging button. 
**[30:20] coolcamilla:** But does it even make sense to change the key bindings, or just change the key for digging? Which is better? Well, it’s just that we don’t really have that many buttons left that we could change. Basically, we could just remove the mouse click for digging and assign it to another button-that’s it. Or we could go the extra mile, so to speak, and add some kind of settings so that all the keys can be remapped. 
**[30:58] Customer:** Don’t try to do anything you won’t have time for. We don’t need anything new. 
**[31:06] coolcamilla:** Okay, then, I’ll remove it.
**[31:10] SunrisEe41:** Here’s another interesting question from the list. Is the customer already using our product? Do you use our product in any way?
**[31:23] Customer:** Hmm, well, not at the moment. In the long run, if you release it on itch. First and foremost, I saw this as an experience specifically for you guys.
**[31:39] coolcamilla:**  We actually understand that, too. 
**[31:41] Customer:** And for your game designer, first and foremost.
**[31:45] coolcamilla:** One more question. Well, since you’re not using it, why not? 
**[31:40] SunrisEe41:** No, well, that’s already… that’s already been answered. Like, if it were on itch... 
**[31:54] Customer:** No, look, yes, guys. On itch., it’ll be used by the audience, and the goal will be achieved as such. If we’re looking at the concept of making money, well, again, you can upload it to Yandex. Well, that’s a separate task for you, one you won’t be able to complete in the next week. You’ll still have to struggle with the web build, monetization, and registration. 
**[32:17] coolcamilla:** Well, for now, then, over the next week or so, by the end of it, on itch. 
**[32:21] Customer:** Yes. 
**[32:22] coolcamilla:** Okay. 
**[32:23] Customer:** Just make the page look great. Please. 
**[32:27] coolcamilla:** Now, well, as I understand it, the game isn’t available anywhere… ah, well, go ahead and ask. Ask away, ask away. 
**[32:44] SunrisEe41:** What needs to happen in the seventh week to complete the handoff? I mean, the part we’ve already… the handoff, yeah. So if we, like, hand over the Unity Version Control project and the GitHub repository to you, will that count as a completed handoff? 
**[32:59] Customer:** If you upload another page to itch.io and get 200 reviews on it. Well, I’m kidding, I’m kidding. Just make a good page. 
**[33:08] coolcamilla:** So, would itch, Unity Version Control, and GitHub be enough for you?
**[33:13] Customer:** Yes. 
**[33:16] coolcamilla:** Now... 
**[33:19] SunrisEe41:** How can we increase the chances that the product will remain useful after our demo is finished? 
**[33:25] Customer:** If you take what you’ve learned from it and go on to make great games. You should still refine it and polish it, because, well, again, the concept itself isn’t complicated or bad. It works; it just needs some polishing. 
**[33:43] coolcamilla:** Okay, so now, just a quick... A quick Q&A. Will the project be ready for “independent use” after we hand it over in week seven? Whatever “independent use” means. Well, it’s more like… whether the game will work overall after we stop working on it. 
**[34:14] Customer:** No, well, it’ll work, right… 
**[34:21] coolcamilla:** I think this is more about various websites where, so to speak, it’s already hosted. 
**[34:28] SunrisEe41:** SWP was built for that, not for games. 
**[34:30] coolcamilla:** Yeah, well, anyway, it’ll be ready. For now, you can also use the current build on its own. 
**[34:45] Customer:** Right
**[34:47] coolcamilla:** And… well, did we understand correctly that you haven’t actually uploaded any builds anywhere yet?
**[34:54] Customer:** No, no, no. 

### Transition-Readiness Meeting ends

**[34:57] coolcamilla:** Well, we know that. So then… That’s it, I think. Well, to sum it up, basically. Change things there… well, make the interface decent, then also… 
**[35:11] Customer:** Digging, tweak the stamina, tweak the location, tweak the player’s objective. Yeah, the stamina should be set up again so that it completely depletes.
**[35:34] coolcamilla:** So that it completely what? 
**[35:35] Customer:** Depletes. And in the beer, you could add the option to... 
**[35:40] coolcamilla:** ...to restore it? 
**[35:41] Customer:** To boost the speed… well, not so much restoration, but specifically to boost the cat’s movement speed so you can get back normally. That way, it’ll balance out.
**[36:06] coolcamilla:** Well then, I think that’s basically how it is for us… well, these, so to speak, not exactly cutscenes, but these in general. Like, there’s a beginning and an end, so we just need to refresh the stamina, loop the scene, and make a normal user interface. Then that’s pretty much it.
**[36:26] Customer:** Yeah, digging is cool. And the animation still needs some polishing-right now it’s just boom-boom. Loop it to match the action, just like the mole’s movements. Well, that’s mostly just for fun. 
**[36:43] coolcamilla:** Well, that’s just a cosmetic tweak now. 
**[36:45] Customer:** And make the decals a little smaller, please. That’s about it, right? 
**[36:51] coolcamilla:** Yes, thank you!
**[End of the interview]
