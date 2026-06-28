[00:09] SunrisEe41: We’re recording this.
[00:10] Customer: You didn’t know what was in store for you today?
[00:15] coolcamilla: Oh, wait-do we need to film the UAT for the video?
[00:19] Customer: Yes, right now-it depends on what you show us.
[00:26] coolcamilla: Can you look it up for now?
[00:31] SunrisEe41: Do we need to film the UAT on video?
[00:50] coolcamilla: So, what did we accomplish this week? In terms of major milestones. We mainly focused on improving the game’s quality and increasing its visibility. But we also added one new mechanic and essentially completed the game loop. We added a drill. It has three stats: fuel tank capacity, drill bit durability, and engine power. Now, regarding the Sprint Backlog, here’s what we’ve done
[01:32] Customer: We were just looking at the website and working on it. I went into Steam, into Preferences, and found a project there where you run in first-person with your buddies alongside a giant drill as your base and level it up-it looks pretty simple
[01:51] coolcamilla: They stole the idea 
[01:53] Customer: Yeah, yeah, yeah, how could it be otherwise? 
[01:54] coolcamilla: Well, so, first of all, what we’ve got here is that we’re leveling up the drill, and then we fixed the jumping. Now the mole can’t fly off the map. Then there was this other thing… Oh, something didn’t work at all… Anyway, we drew, animated, and refactored the code-specifically the blocks, inventory, and pause features. We also wrote tests. There are three types of tests: Quality Requirements tests, Edit Mode tests, and Play Mode tests. Our main problem there was that basically everything was implemented as a MonoBehaviour. Well, in short, it wasn’t separate-C# was simply inherited from MonoBehaviour-and because of that, we couldn’t write proper unit tests. So we were kind of working on separating things out. Then, well, the documentation too, and there’ll also be something like a session-basically, you’ll be playing through it; that is, we’ll provide the steps and you’ll repeat them all to see how it works. And then, well, Marat came up with some additional ideas… he basically figured out the content. 
[03:20] Customer: WazzuRunaway, could you post a screenshot of the table you designed? 
[03:34] coolcamilla: Right now. Next week we plan-well, once we’ve tested all this and set it up-to continue by focusing on the features again and adding, overall, the layers we’ll have, spawns and deposits, mining stations, and if we have time, we’ll add improvements for the mole. Here’s the idea. We had to figure out a way to keep players interested, so we came up with this: the drill can randomly drop resources or various upgrades for the mole. So the player is playing, randomly runs up to the drill, and there’s something like: “Wow, an awesome golden ring-plus 5 to digging speed.” And they get excited and equip it.
[04:25] Customer:  +5 relative to 200. We can test that out now, right?
[04:27] coolcamilla: Yeah, well, for now, rings aren’t dropping from the drill-only sticks are. Digging sticks. By the way, I think we decided to cut out the saplings in the end, but they’re still there for now.
[04:50] Customer: How’s it going with the guy on the fifth team who keeps making things up? Were you able to deal with him?
[04:59] coolcamilla: Yeah, he wasn’t making things up on this one-he’d already explained everything he’d come up with. So, I’ll repeat what I told you earlier: the Product Increment includes the fact that movement has been fixed again, and procedural generation has been added. Also, there’s now a drill that digs autonomously-I’ve already mentioned its specs. And it turns out tests were written for it, and they have 52% coverage.
[05:33] Customer: What does that mean, guys?
[05:37] coolcamilla: Well, it means that during testing, 52% of all lines of code are tested at least once. And now we can also see how we responded to your feedback-what we did based on it. It turns out we removed the drag-and-drop functionality. We haven’t removed it and don’t plan to, because it’ll come in handy in the future when we need to refuel the drill.
[06:07] Customer: So, why would you need to refuel it using Drag and Drop? 
[06:11] coolcamilla: Well, generally speaking, it’s not refueled using Drag and Drop yet. Midweek, we decided we needed it, and we haven’t removed it yet.
[06:25] SunrisEe41: That’s new feedback.
[06:26] coolcamilla: Yes, that’s new feedback. We’ll remove it if necessary. But we haven’t done that yet. Then we fixed the movement-we did that.
[06:35] Customer: So you added it and fixed it?
[06:37] coolcamilla: Yes, we fixed it.
[06:41] Customer: Well then, guys, what about the approach animations? Are there any for this? The mole doesn’t approach-that’s fine.
[06:49] coolcamilla: As for unique mechanics for the mole, we have a “climbing mode,” but it wasn’t there last time. It was actually written just last week, but now it’s implemented everywhere-meaning it can crawl along background walls. Then there’s the risk mechanic-we’ll have that, but we’re still thinking it over, and we’ve come up with the perfect solution. Here’s how it works: the mole moves toward the ground, and the deeper he goes, the hotter and warmer the ground gets, so he starts to overheat. That’s why he needs to cool off, climb back up, and have a beer. And then go back down again. There you go. So basically, his only goal is to run up, have a beer, and then go back down. 
[07:29] Customer: So is this an interpretation of Seryozha’s life? Seryozha is speaking from the channel. 
[07:39] coolcamilla: Exactly. And we’re also thinking about incorporating something-well, since we’re in Innopolis, in Tatarstan, we should incorporate some Tatar culture. Maybe we’ll add a skufia.
[07:50] Customer: No, guys, that’s not necessary. But it’d be okay-it wouldn’t be bad. Like a secret feature or something. Yeah, yeah, yeah.
[07:57] coolcamilla: A tyubeteika, then some Tatar music. So, plus five speed from the ring and plus five… Oh…
[08:04] Customer: Well, it’d be cool if there were some mechanics. I mean, if you make three items, those three items would change one mechanic. For example, a character might learn to run fast, crawl faster, or leave something behind when they destroy something. If you create a couple of mechanics like that-and the way it feels-it’ll be way cooler than just +5 to speed. 
[08:25] coolcamilla: Then there’s the fact that… Well, it turns out his goal is to return to the surface-that goal appeared because if we leave beer behind, he’ll need to drink it. Plus, he has to go to the drill. I mean, the drill keeps moving, moving, moving from time to time, but it runs out of fuel, so he has to run and refuel it. Now about the visibility limit. We haven’t worked on that yet-we’ll be tackling it next week.
[08:58] WazzuRunaway: We’ve focused most of our efforts on the drill. 
[09:01] coolcamilla: We also haven’t implemented saves yet, but they’ll be added next week. And as for crafting multiple times-you’ll kind of notice that today. It’s so that we... 
[09:13] Customer: You’ll feel it.
[09:15] coolcamilla: We’ve implemented the new feedback. Okay, so, are we good to go now? 
[09:26] SunrisEe41: So, will it work on your end? Because it’s probably better to record it in OBS after all.
[09:35] coolcamilla: Oh, okay. Can you show me the steps, then?
[09:41] SunrisEe41: Sure.
[10:28] Customer: Have you played any of the Reference games?
[10:31] WazzuRunaway: Yeah. Well, like... we played *Forager* and *Steam World Dig*. And we played some other Reference-related games, too.
[10:45] Customer: And he was able to move around in the menu, I think?
[10:50] coolcamilla: No. I don’t think so. Or maybe yes. Okay, let me see. I can just list the steps from here and go through them-I don’t even have to show you. Oh, well, anyway. So, first: we need to check that we fixed the movement. We need to click “Load Game”-you know, the one for a new game.
[11:44] Customer: “New Game” doesn’t work, right?
[11:46] coolcamilla:  No.  I don’t think it does right now. “New Game” isn’t working right now.
[11:53] Customer: Are there any alternatives to the LKM button? 
[11:56] coolcamilla: Not yet.  We’re planning to just change the key bindings altogether. Anyway, right now you need to go to the white wall on the right. I mean, on the right side of the map. 
[12:08] Customer: Won’t the left side work?
[12:10] coolcamilla: Well, the drill is already on the left right now, so it’s better on the right. Okay, now you need to press the spacebar. And he should jump. Now press D and then the spacebar.  And he’ll kind of jump to the right. What’s going on there?
[12:40] Customer: How did you figure that out? How does it work?
[12:46] coolcamilla: Well, now he won’t jump up. I mean, he’s right up against the wall-he can’t climb up it. That’s the idea. Anyway, right now, basically, if you hold down D and just quickly press the spacebar, he won’t climb up the wall. Well, he shouldn’t, at least. I hope so.
[13:07] Customer: So I’d switch to climbing mode.
[13:09] coolcamilla: No, don’t switch to climbing mode just yet. 
[13:15] Customer: Okay, at first he just jumped over the wall. He’s some kind of jumping mole, right? It’s just that here, when you grab onto the corner, he can make a really high jump.
[13:26] SunrisEe41:  Yeah, there’s that. It’s a mechanic. That’s how it’s designed. 
[13:30] WazzuRunaway: A jump. 
[13:31] Customer: Man, that’s cool. Give him a jump. Well, give him some kind of special move.
[13:41] Customer: So it turns out we can do it this way.
[13:50] Customer: He used to jump over that wall. Now he can’t do it.
[13:57] coolcamilla: He can’t climb up the wall right now. In theory
[14:02] Customer: He used to be able to.
[14:04] coolcamilla: Yeah, he used to be able to.
[14:06] WazzuRunaway: And he’d fall down.
[14:08] coolcamilla: But now he’s-that’s it. He’s in the world outside the walls.
[14:11] WazzuRunaway: It’s like that for now to make it easier to work on. We’ll tweak it later.
[14:20] Customer: Okay.
[14:22] coolcamilla: So, now when the mole lands on the ground, you can press A/D and notice that, well, basically, its normal movement hasn’t changed after being locked in place. Alright. 
[14:38] Customer: Guys, no, that’s not right. 
[14:45] SunrisEe41: It’s still a little more than one block. 
[14:51] coolcamilla: Now for the next test. Can you dig a hole? 
[14:59] Customer: I can dig a hole.
[15:01] coolcamilla: Well, anyway, you need a 4x4 block area. 
[15:05] Customer: Coming right up. 
[15:06] coolcamilla: Well, 2x4 would work too. 
[15:07] WazzuRunaway: You’ll need climbing skills for this. 
[15:10] Customer: I have some experience. Actually, no. 4 by 4. Would 5 by 5 work? 
[15:19] coolcamilla: Yeah, that’ll work. 
[15:21] Customer: What about 5 by 4? 
[15:22] coolcamilla: That’ll work, too. A 2-by-2 grid would work there overall.
[15:27] coolcamilla: Okay. Now you just need to fall into that pit, basically.
[15:30] Customer: Okay, I’m already in it. I dug it for him myself
[15:32] SunrisEe41: Progress, progress.
[15:34] coolcamilla: Now press C. It’s switched to climbing mode.
[15:40] Customer: Yeah, but that’s what it was like from above, too. That’s how it’s done outside, too. 
[15:45] Customer: Why do I need to dig a hole? 
[15:49] SunrisEe41: Well, for now, the part at the top is for debugging.
[15:52] Customer: It feels more complete here. 
[15:55] coolcamilla: Now, if you press WASD, he’ll crawl.
[15:57] Customer:  Why 4, why 4? Until they’re dug up, the mole isn’t set up. He definitely needs to take a course in meditation-meditation. Digging a hole. 
[16:10] SunrisEe41: He’s not feeling well. 
[16:12] Customer: Digging therapy.
[16:14] coolcamilla: So, basically, with WASD he walks calmly along the walls, and now, if you press C again, he falls. Well, and he stands on the ground. Great. Now for the next test. First, you need to collect 10 sticks. 
[16:30] Customer: Okay. I collected them. 
[16:33] coolcamilla: Oh, you did?
[16:34] Customer: It took two seconds, yeah. 
[16:35] coolcamilla: All right, good.
[16:36] Customer:  I found a quick way to farm them. 
[16:38] coolcamilla: Okay. 
[16:39] Customer: You just have to walk back and forth for about 10 minutes, digging them out of the ground. I don’t know what the sticks are doing in the ground. I guess there’s some deeper concept behind it. [16:25] SunrisEe41: Old trees. 
[16:55] coolcamilla: The saplings. Okay, now you need to press “E.” You’ll see that your full inventory and the crafting menu have opened. You can browse through the crafting menu. There are two tools there. Click on the wooden shovel. Information about the wooden shovel should pop up, along with a “Craft” button. Now you need to click the craft button. A wooden shovel will appear in your inventory, and the resources required to craft it will be deducted from your inventory.
[17:30] Customer: Oh, you added animations. 
[17:31] coolcamilla: Yes. So now you can try clicking the craft button again. 
[17:40] Customer: We’re having a meeting here. Cool. Guys, please, just fill it in and you’ll be in good with me.
[18:01] coolcamilla: You can try clicking the “Craft” button for the shovel again right now, and the shovel won’t craft because there aren’t enough resources. Do you have enough?  
[18:10] SunrisEe41: The whole map’s almost dug up, just so you know. 
[18:16] coolcamilla: Let’s say we didn’t have enough. 
[18:20] SunrisEe41: Well, if we craft three more shovels, we won’t have enough. 
[18:21] coolcamilla:  So, let’s move on. Let’s go to the inventory. 
[18:27] WazzuRunaway: He can’t dig upward when he’s climbing. Or downward, for that matter. 
[18:30] coolcamilla: Now about the inventory. Well, it turns out you should break any blocks that are left. 
[18:40] Customer:  Oh. Right. Okay. 
[18:44] coolcamilla: And now walk through the dropped resources. They should appear in your inventory. 
[18:53] Customer: Well, considering I’ve already made a shovel. 
[18:54] coolcamilla: That means a new world is simply being generated each time. Now try crafting something. Well, for example, a pickaxe, since you have a shovel.
[19:03] Customer: Got it.
[19:04] coolcamilla:  There you go. And, well, everything seems to be working great. As you can see, the pickaxe has been added to your inventory, and the resources have been deducted from your inventory. So everything is being tracked correctly, in the right amounts. 
[19:23] coolcamilla: Is there anything you don’t have enough resources for?
[19:25] WazzuRunaway: No.
[19:28] coolcamilla: And now-one last thing. We need to see how the drill works. That’s the most interesting part. We need to go to the left on the map. 
[19:39] SunrisEe41: We’re about to run out of stone, too.
[19:45] SunrisEe41: We should have added the warehouse right away after all. 
[19:50] coolcamilla: I think we just need to increase the stack size. Otherwise, 16 isn’t enough. 
[19:54] Customer: Over there, right? 
[19:56] SunrisEe41: Yeah, there’s a path there. 
[19:58] coolcamilla: Yeah, we need to press F. 
[20:00] WazzuRunaway: No, it’s next to the sign. 
[20:15] Customer: Don’t look. 
[20:17] SunrisEe41: Yeah, he’s been practicing. He’s flying toward the camera.
[20:26] Customer: No wonder I was digging for 15 minutes. You’ll learn all sorts of things. Okay, Press F to interact. Wow!
[20:31] coolcamilla: Did the drill open?
[20:32] Customer:  Yes. 
[20:33] coolcamilla: There you go, great. Don’t do anything yet. Now, you can see that there’s no fuel right now. 
[20:42] Customer: Yes.
[20:43] coolcamilla: And the drill isn’t moving.
[20:43] Customer:  Yes. 
[20:46] coolcamilla: It’s moving now, right? 
[20:48] SunrisEe41: Well, just a little bit-it’s still weak for now. 
[20:51] Customer: I can remove the rod. Okay, go ahead.
[21:00] coolcamilla: Now put one rod in the tank. As you can see, the drill has started. And the depth has started to change. Now it’s working.
[21:09] Customer: Where is it digging? 
[21:13] WazzuRunaway: Way up in the sky. 
[21:17] Customer: Wow, that’s cool-heavenly islands-sold.
[21:23] coolcamilla: There you go, and now you can choose an upgrade. Well, over there on the right, you’ll see the upgrades. You can choose any one you like from the list-well, whichever one you have enough resources for-and click “Upgrade.” The drill’s stats should change. Either the speed increases or the fuel tank capacity does.
[21:45] Customer: I don’t have enough. I’ve run out of everything. There are no more upgrades. 
[21:55] SunrisEe41: You’re not running out of resources-you’re running out of upgrades.
[22:00] Customer: How do I exit? 
[22:01] SunrisEe41: F.
[22:02] WazzuRunaway: F, or you can just walk away. 
[22:06] WazzuRunaway: Are you planning to place the drill in the center of the map? 
[22:10] coolcamilla: Well, from what I’ve seen at least, the drill won’t actually be visible-it’ll just be there like this sign. I mean, here’s the main point of the drill: Right now, the mole can craft a pickaxe once it collects 5 stones. But  the idea is that he won’t be able to do that. In other words, to turn the soil into stone, the drill has to dig all the way down to the stone. Then, for example, the mole gets 5 stones from the drill.
[22:42] Customer:  And he uses them to make… 
[22:44] coolcamilla: A tool to move on to the next layer.
[22:45] Customer: Cool. Cool, yeah, great 
[22:46] coolcamilla: And so the goal of the whole game is essentially not for the mole itself to drill through, but for its drill to do so. 
[22:52] Customer: Man, that’s cool. When I was pitching ideas back in the winter-around New Year’s at the club-there was this idea to make, basically, “how to dig a hole,” but in Antarctica, where you’re watching the drill, that’s when the horror starts. And that’s exactly when your main goal is to make sure the drill keeps digging deeper.
[23:13] Customer: They stole the idea. 
[23:15] Customer: Yeah. So that’s how it is. And you can’t dig down in climbing mode, right?
[23:18] WazzuRunaway: You can’t dig down or up.
[23:20] Customer: Well, not in that way. It probably makes sense to actually design climbing mode so that it’s strictly up and down, so it’s easier to understand.
[23:35] coolcamilla: I actually thought that in climbing mode, it couldn’t dig at all. 
[23:42] Customer: Or make climbing mode something permanent. I mean, when you just press W, your mole starts crawling, but it uses up stamina, like in some Zelda game.
[23:55] WazzuRunaway: We had that idea, too. But we were working on other things this week. We’ve also thought a lot about climbing. 
[24:02] Customer: The map is almost finished. 
[24:06] SunrisEe41: What else did we have? 
[24:09] WazzuRunaway: Oh, and there were some more drops from the drill-you can go check them out. 
[24:12] Customer: I’ll go check it out now. 
[24:18] coolcamilla: Well, that’s pretty much it. But do you have any comments? 
[24:24] Customer: I want to go to the sky. 
[24:26] coolcamilla: Press the spacebar a lot.
[24:30] WazzuRunaway: Press pause and keep pressing the spacebar.
[24:32] coolcamilla: Or press the spacebar and AD at the same time. 
[24:35] WazzuRunaway: That’s probably too much. It’s shooting way up into the sky. 
[24:39] SunrisEe41: I didn’t find anything like that when I was writing the tests.
[24:42] WazzuRunaway: But Pro100Vorona found it. 
[24:44] SunrisEe41: Pro100Vorona was the one in charge of the pause.
[24:46] coolcamilla: What’s going on there? 
[24:48] SunrisEe41: The mole just ends up in the sky. 
[24:48] WazzuRunaway: The mole is flying right now. 
[24:53] WazzuRunaway: But not right now-he’s not on the ground when the forces are applied. He’s picked up a lot of speed. 
[25:06] SunrisEe41: Am I right in thinking that he can jump when his speed is literally zero?
[25:08] WazzuRunaway: No, when he’s on the ground. His legs act like a collider-when they touch the ground, he can jump. And when he’s paused, forces are still being applied; they accumulate.
[25:22] customer: Cool, yeah. Apply stamina to movement. And remove the separate button for climbing. Overall, I’d like to simplify the button layout as much as possible. The mechanics don’t warrant it. The drill, of course, needs to be the central-key-mechanic. And add beer-beer is awesome. We just need some kind of mascot gimmick so it’s not just a mole, but a mole with a twist.
[25:52] coolcamilla:  There was also an idea for him to drink Tatar tea instead of beer.
[25:56] customer: Second, of course, I’d like to see improvements right here. That is, again, without unnecessary inventory. Right now, it’s way too complicated for no reason. Or, again, with a separate workbench. Just a workbench near the drill would be fine. You can both work on it and level up there. 
[26:32] WazzuRunaway: That way, the interface is less cluttered, too.
[26:36] customer: And you could set limits based on the slots you’re leveling up. That would be nice-really cool.
[26:48] customer: And about the slots-he has 5 of them, and they’re always for tools?
[26:53] customer: Yeah, always for tools. A shovel and a pickaxe are the same thing. [27:00] WazzuRunaway: A shovel doesn’t break rocks. 
[27:05] customer: Why? Just make a pickaxe-shovel hybrid and be done with it. Well, so it levels up gradually, because right now the tools don’t really affect anything. Tools are needed when the game has a system like in Stardew Valley, specifically one that separates different types of rock. Yours has just one function. 
[27:27] WazzuRunaway: So, a pickaxe is essentially the next level of a shovel.
[27:30] customer: Yeah. 
[27:35] coolcamilla: So the character always has one weapon, but it just levels up?
[27:42] customer: Yeah. 


[Unrelated to the interview]


 [28:37] Customer: And for the mole, of course. 
[28:39] coolcamilla: Make it into a single block?
[28:41] WazzuRunaway: Well, that’s been needed for a long time.
[28:43] Customer: Yeah, the movement needs some tweaking. And we need roll animations. Okay, I’m not taking the roll animations that seriously right now. I’d rather have something fun in the movement, so it’s really fun to walk back and forth. So it’s really… bouncy. 
[29:02] coolcamilla: We should probably send this to MarikSH.
[29:04] Customer: Yeah, well… All right, fine.
[29:15] coolcamilla: Well, unfortunately, not everything is covered yet. To be honest, I don’t really understand why we need to show you all this, but… Now, getting back to what we were doing. So, we’ve outlined the Quality Requirements-SunrisEe41 did that. 
[29:57] SunrisEe41: Those technical details-I’ll find them now; I wrote them in the README, based on the ISO/IEC 25010 specifications.
[30:10] customer: 25010-what does 25010 cover? I just happened to be defending the ISO 26000, 9000, and 45000 specifications on my exam.
[30:24] SunrisEe41: I didn’t know people actually used them.
[30:28] customer: Yeah, people actually sit there and say, “26000-that’s fine!”
[30:32] SunrisEe41: We test time behavior. There’s a grid generator script, and within 3 seconds of a scene loading, it spawns this grid-it generates it. So we’re testing for time; in Unity, this is automated, but we’ll still need to integrate it into GitHub CI. As for fault tolerance, we test it using the “block behavior” script. If there’s no information about a specific block, it doesn’t crash but logs an error instead. And operability means that the game starts without being paused. One frame after the game launches, the timescale immediately becomes 1. These are the Quality Requirements we’ve established. 
[31:35] customer: Great work!
[31:43] coolcamilla: Now, about the three critical modules that need to be tested. So far, these are the inventory, crafting, and procedural generation.
[31:58] customer: Movement for the characters. Guys, guys. 
[32:00] WazzuRunaway: Movement is very difficult to split up right now.
[32:06] coolcamilla: Our tests mainly cover the inventory, crafting, procedural generation, and menus. As we’ve already mentioned, Quality Requirement Tests, Edit Mode, and Play Mode tests were written for this purpose. 
[32:34] SunrisEe41: I’ll start by talking about the integration tests. For the critical modules we’ve identified, coverage is around 80–100% for each of these modules. In other words, overall, these modules are fully tested in collaboration between teams. As for unit tests, all these modules are already tested individually in C# classes with nearly complete coverage as well. We also had an additional QA check. We’ve implemented Roslyn NetAnalysers. This specifically checks the code to ensure that… if a method returns something, we actually use it. In other words, there are no “discarded” method returns. Methods that are supposed to be static are indeed static. All of this will be checked on every pull request.
[34:06] coolcamilla: Would you like to add anything? What should we add to the checks, or how should we change our approach?
[34:22] customer: No, everything’s fine. I’m really looking forward to seeing a working game design from you. It’s great that you’re already testing and implementing it, but usually in development this starts after the demo is ready. Anyway, everything’s good, everything’s great.
[34:45] coolcamilla: And here’s one last thing. This is definitely the last one for today. It’s about the risks we’re currently facing.
[35:00] customer: Oh, great, let’s hear it.
[35:11] coolcamilla: As for testing, we’ve already discussed that there aren’t enough unit tests because it’s hard to separate the logic. We also identified an issue with the game’s scope. We come up with a lot of ideas, so we need to keep what’s important and discard what’s unnecessary. For example, the saplings-we got rid of them. Right now, we’ve more or less arrived at a unified vision for the entire game. We’re going to have MarikSH work on coming up with the actual content. There’s no save system yet, but it’s too early to implement that. 
[36:09] SunrisEe41: Well, overall, the whole game crashes within 5 minutes so far. 
[36:17] coolcamilla: And in the future, we’ll add resource-harvesting stations, as well as layers. We’re currently planning for 6 layers in the final game, but I don’t know if we’ll be able to pull it off. 
[36:37] customer: Three is enough, as long as they’re well-developed. For 10–15 minutes of gameplay. 
[36:48] coolcamilla: As for risk mechanics, we’re going with beer and overheating. I’m not sure yet if we should add limited visibility and lanterns. 
[37:13] customer: I’d like to… I’d add them. Not so much the lanterns, but the fact that you don’t know what blocks are nearby. Actually, why don’t you add coins? Everyone loves money. Just add coins buried in the ground that you collect, and use them to upgrade things. Then it’ll actually be interesting. The biggest risk is that the game will turn out to be boring, and I’ll get bored moving around. Movement and exploration-they need to be thought through 100%. Figure out why SteamWorld Dig, Forager, and other digging games feel so fun. 
[38:19] coolcamilla: We’ll probably keep the mole upgrades, too. 
[38:27] SunrisEe41: You could make them available for coins.
[37:13] customer: Yeah, yeah, yeah. We can make them interesting. And add a climbing mode. And stamina, and inventory limits. Basically, just throw in some restrictions, and that’s it: the game suddenly becomes interesting because you’re setting boundaries. Freedom lies within those boundaries. 
[38:52] coolcamilla: We’ve got white walls. Want us to add a white ceiling too?
[38:57] customer: Man, by the way, that’s a cool idea-like a mole trapped in someone’s pen. And our goal… 
[39:00] coolcamilla: He’s trying to dig his way out, but in the end, he just hits a glass wall. 
[39:10] customer: And he’s trying to snap out of it by drinking beer. 
[39:13] coolcamilla: He actually understands everything, but he’s sad-it’s the realization that it’s all unreal.
[39:20] customer: Because of this system where he has to go to work every day, dig, collect gold, come back, and do it all over again. 
[39:33] SunrisEe41: At first, I thought the mole was just an alcoholic, and if he doesn’t have a drink within five minutes, he starts feeling sick.
[39:37] customer: Sold! That’s a bit over the top, but it’s already sounding interesting. You need some kind of story about the game mechanics-something that makes people hear it and think, “Yeah, I want to play this-okay, that’s interesting!” For example, with your game, I immediately picture a meme where a guy is digging for diamonds, but in your game, it’s a mole digging for beer.
[40:05] coolcamilla: You know why the coins are there? There’s a beer vending machine on the surface, but the beer isn’t free, so you have to collect coins to buy yourself a beer. And if he doesn’t drink beer, he’ll die.
[40:25] customer: Set it up like an aquarium. That already brings life to your project. That’s already something cohesive... 
[40:44] coolcamilla: Okay. Also, what are your recommendations for what we should do next week?
[40:50] customer: Movement, simplifying the inventory. The drill in the center, if you have time. The beer can wait, but it would be good to explore the aspect of uncertainty regarding nearby blocks-which we’re also working on-as part of our research. So, for example, you could create a flashlight that’s always attached to the mole. 
[41:20] coolcamilla: He has a flashlight on his helmet. We can work on that. 
[41:28] customer: Check out how blocks break in SteamWorld Dig. 
[41:30] WazzuRunaway: We already have a sprite for that. It should be easy to implement. 
[41:39] coolcamilla: Should we hold off on adding anything completely new for now?
[41:41] customer: No, no, no-just finish what you’re working on; that’ll be great already. 
[41:50] coolcamilla: Pro100Vorona is also going to add procedural generation for ore deposits
[42:00] customer: Well, that’s not necessary for the demo. You can leave it manual for now. I mean, I get that there’s always someone on the team who really wants to add procedural generation so that every run is unique. 
[42:43] coolcamilla: Anything else to add?
[42:56] customer: The part with the code and unit tests-great work.
[43:07] coolcamilla: Well, that’s it for now. 


[Unrelated to the interview]
