# Week 7 Reflection
 
## Learning Points
- Shipping a mechanic without corresponding player-facing feedback is a recurring pattern, not an isolated gap.
- Asking the customer directly about acceptance criteria produces immediately actionable prioritization guidance.
- Pushing back on customer feature requests in real time protects the team from late-stage overcommitment. For example, the proposed circular/looping world was honestly assessed as unclear and difficult mid-meeting rather than agreed to and then dropped later.
- A feature that repeatedly gets pushed from Sprint to Sprint without ever being prioritized is a signal the feature itself should be reconsidered, not just re-scheduled.
- Running Sprint 5 as a maintenance and polish Sprint, rather than a features Sprint, required an explicit scope-narrowing conversation with the customer. Stating plainly what would not be done was as important to agreeing final scope as listing what would be done, and prevented the meeting from drifting into new feature requests.
- Confirming the transition criteria directly and early in the meeting (rather than assuming it) turned an ambiguous handover requirement into a concrete, closed question. It gave the team a fixed target for the remaining transition work instead of an open-ended one.
- Customer usefulness after course end is not guaranteed by finishing features. It depends on whether the product genuinely stays interesting to play.

## Validated assumptions
- We assumed removing mouse-only digging in favor of keyboard input would resolve the control complexity complaint - confirmed during customer trial
- We assumed the redesigned drill UI mockup approved last Sprint Review would read as more polished once implemented - partially confirmed during UAT session (padding, button sizing, and font execution problems remain)
- We assumed the drill's mining progress was sufficiently perceivable to the player without dedicated UI - rejected during customer trial  
- We assumed the introductory cutscene and tutorial together would clearly onboard a new player - confirmed during UAT session
- We assumed the customer would want to continue developing or maintaining the product independently after handover - rejected during the transition discussion  
- We assumed gameplay balance was the main thing still missing for the product to feel complete - rejected during the trial session  

## Friction and gaps
- The digging animation plays twice per single input press and runs in the wrong direction  
- The mole can become stuck on ground tiles and continues to float/crawl while on air tiles instead of exiting movement states correctly  
- No resource-pickup confirmation UI exists anywhere in the game  
- Crafting recipes and drill upgrades give no visual indication of whether the player currently has enough resources to afford them  
- The world is not circular; boundary walls were changed from opaque to transparent this Sprint but full looping was assessed as unclear to implement in the remaining time  
- Coin-bearing blocks are visually indistinguishable from regular blocks, giving the player no signal about which blocks are worth digging toward
- Long-term product usefulness beyond course delivery depends on content variety (block/resource diversity) that does not yet exist, which is a larger scope item than anything currently planned for the Sprint 5

## Planned response
No PBIs, only small polish fixes during Week 7:
 
- Fix the digging animation double-trigger and incorrect playback direction
- Fix the mole getting stuck on ground tiles and floating on air tiles
- Add a resource-pickup confirmation indicator (icon + count)
- Add availability indicators to crafting recipes and drill upgrades
- Improve padding, button sizing, and font consistency on the redesigned drill UI

