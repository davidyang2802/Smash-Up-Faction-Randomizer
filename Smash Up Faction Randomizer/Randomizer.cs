using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smash_Up_Faction_Randomizer
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        int players;
        Singleton SmashUp = Singleton.Instance;

        /// <summary>
        /// Loading of Main form. Initializes Singleton SmashUp and generates the checkslists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SmashUp.Initialize();

            displayGameOptionsMode();
            
            generatechecklistSets();
            generatechecklistFactions();
            generatechecklistLocks();

            cbPlayerCount.SelectedIndex = 0;
            foreach (Singleton.GameMode gm in SmashUp.GameModes)
            {
                cbGameMode.Items.Add(gm.Name);
            }
            cbGameMode.SelectedIndex = 0;
            tbGameModeDescription.Text = SmashUp.GameModes[0].Description;
        }

        #region Game Options Mode
        /// <summary>
        /// Method that turns all the Game Options Mode controls visible
        /// </summary>
        private void displayGameOptionsMode()
        {
            tbPlayerCount.Visible = true;
            cbPlayerCount.Visible = true;
            tbGameMode.Visible = true;
            cbGameMode.Visible = true;
            tbGameModeDescription.Visible = true;
            tabsLists.Visible = true;
            btnSmashUp.Visible = true;
        }

        /// <summary>
        /// Method that turns all the Game Options Mode controls invisible
        /// </summary>
        private void hideGameOptionsMode()
        {
            tbPlayerCount.Visible = false;
            cbPlayerCount.Visible = false;
            tbGameMode.Visible = false;
            cbGameMode.Visible = false;
            tbGameModeDescription.Visible = false;
            tabsLists.Visible = false;
            btnSmashUp.Visible = false;
        }

        /// <summary>
        /// Event method that updates the Game Mode description when it's changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbGameMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbGameModeDescription.Text = SmashUp.GameModes[cbGameMode.SelectedIndex].Description;
        }

        /// <summary>
        /// Method to generate the checklist for the Sets. Note that this should only be called once
        /// </summary>
        private void generatechecklistSets()
        {
            foreach (Singleton.Set s in SmashUp.Sets)
            {
                checklistSets.Items.Add(s.Name);
                checklistSets.SetItemChecked(checklistSets.Items.Count - 1, s.Enabled);
            }
        }

        /// <summary>
        /// Method to generate the checklist for the Factions. This will be called multiple times to regenerate the Factions list based on the Set checklist
        /// </summary>
        private void generatechecklistFactions()
        {
            // First clear the items list
            checklistFactions.Items.Clear();

            foreach (Singleton.Faction f in SmashUp.Factions)
            {
                // The set needs to be enabled in order for the faction to be added to the items list
                if (SmashUp.Sets.Exists(s => s.Name == f.Set) && SmashUp.Sets.Find(s => s.Name == f.Set).Enabled)
                {
                    checklistFactions.Items.Add(f.Name);
                    checklistFactions.SetItemChecked(checklistFactions.Items.Count - 1, f.Enabled);
                }
            }
        }

        /// <summary>
        /// Method to generate the checklist for the locks. This will be called multiple times to regenerate the Lock list based on the Set & Faction checklist
        /// </summary>
        private void generatechecklistLocks()
        {
            // First clear the items list
            checklistLocks.Items.Clear();

            foreach (Singleton.Faction f in SmashUp.Factions)
            {
                // Both the set and the faction need to be enabled in order for the faction to be added to the items list
                if (SmashUp.Sets.Exists(s => s.Name == f.Set) && SmashUp.Sets.Find(s => s.Name == f.Set).Enabled && f.Enabled)
                {
                    checklistLocks.Items.Add(f.Name);
                    checklistLocks.SetItemChecked(checklistLocks.Items.Count - 1, f.Lock);
                }
            }
        }

        /// <summary>
        /// Method to update SmashUp.Sets based on the Sets checklist.
        /// </summary>
        private void updateSets()
        {
            for (int i = 0; i < checklistSets.Items.Count; i++)
            {
                if (SmashUp.Sets.Exists(s => s.Name == checklistSets.Items[i].ToString()))
                {
                    SmashUp.Sets.Find(s => s.Name == checklistSets.Items[i].ToString()).Enabled = checklistSets.GetItemChecked(i);
                }
            }
        }

        /// <summary>
        /// Method to update SmashUp.Factions Enabled property based on the Factions checklist.
        /// </summary>
        private void updateFactions()
        {
            for (int i = 0; i < checklistFactions.Items.Count; i++)
            {
                if (SmashUp.Factions.Exists(s => s.Name == checklistFactions.Items[i].ToString()))
                {
                    SmashUp.Factions.Find(s => s.Name == checklistFactions.Items[i].ToString()).Enabled = checklistFactions.GetItemChecked(i);
                }
            }
        }

        /// <summary>
        /// Method to update SmashUp.Factions Lock property based on the Locks checklist.
        /// </summary>
        private void updateLocks()
        {
            for (int i = 0; i < checklistLocks.Items.Count; i++)
            {
                if (SmashUp.Factions.Exists(s => s.Name == checklistLocks.Items[i].ToString()))
                {
                    SmashUp.Factions.Find(s => s.Name == checklistLocks.Items[i].ToString()).Lock = checklistLocks.GetItemChecked(i);
                }
            }
        }

        /// <summary>
        /// Event method triggered whenever a different checklist tab is selected.
        /// Whenever this event occurs, SmashUp.Sets & SmashUp.Factions need to be updated accordingly, and then Factions and Locks checklists need to be regenerated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabsLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSets();
            updateFactions();
            updateLocks();

            generatechecklistFactions();
            generatechecklistLocks();
        }

        /// <summary>
        /// Event method triggered when the Smash Up button is clicked. This method finalizes the game options phase and moves towards the faction selection phase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSmashUp_Click(object sender, EventArgs e)
        {
            // First update the sets, factions and locks - we don't particularly know which tab we're on
            updateSets();
            updateFactions();
            updateLocks();

            // At this point, we have the data that we need to proceed
            // We'll need to build up two list - a list of locks and a list of randoms - these are factions that the algorithm will choose from

            SmashUp.Locks = new List<string>();
            SmashUp.Randoms = new List<string>();

            // Loop through all the factions
            foreach (Singleton.Faction f in SmashUp.Factions)
            {
                // So we need to first make sure that the set is enabled - the faction can be enabled but the set isn't
                if (SmashUp.Sets.Exists(s => s.Name == f.Set) && SmashUp.Sets.Find(s => s.Name == f.Set).Enabled)
                {
                    // So now we check if the faction is indeed enabled
                    if (f.Enabled)
                    {
                        // Lastly check if it's also locked, in which case it goes into Locks
                        if (f.Lock)
                        {
                            SmashUp.Locks.Add(f.Name);
                        }
                        else
                        {
                            SmashUp.Randoms.Add(f.Name);
                        }
                    }
                }
            }

            // So now we have a list of factions that are locks and another list that can be randomly selected

            // Here we do need to do some checks to make sure that we can actually proceed
            // First, there cannot be more locks than the number of factions used by the game mode
            players = cbPlayerCount.SelectedIndex + 2;
            int fneeded = SmashUp.GameModes[cbGameMode.SelectedIndex].PoolSizePerPlayer * players;

            if (SmashUp.Locks.Count > fneeded)
            {
                MessageBox.Show(String.Format("There are too many locked factions. Please remove at least {0} locks.", SmashUp.Locks.Count - fneeded));
                return;
            }

            // We also need to check if we have enough factions overall
            if (fneeded > SmashUp.Locks.Count + SmashUp.Randoms.Count)
            {
                MessageBox.Show(String.Format("There are too few allowed factions. Please add at least {0} allowed factions.", fneeded - SmashUp.Locks.Count - SmashUp.Randoms.Count));
                return;
            }
            
            // so at this point, we have both Randoms and Locks - we can now create the faction pool
            random = new Random();
            SmashUp.Pool = new List<string>();
            // Add all the locks if there are any
            if (SmashUp.Locks.Count != 0)
            {
                foreach (string l in SmashUp.Locks)
                {
                    SmashUp.Pool.Add(l);
                }
            }
            // For the remaining spots in the pool, get them from Randoms
            while (fneeded > SmashUp.Pool.Count)
            {
                int iRandom = random.Next(0, SmashUp.Randoms.Count);
                // We want to keep the entire list of Randoms for reference, so we need to make sure the next Random isn't already in the pool
                // This would affect performance, but since there likely won't be so many factions that the performance would be noticeably worse
                while (SmashUp.Pool.Contains(SmashUp.Randoms[iRandom]))
                {
                    iRandom = random.Next(0, SmashUp.Randoms.Count);
                }
                SmashUp.Pool.Add(SmashUp.Randoms[iRandom]);
            }
            // now hide the controls used for the game options
            hideGameOptionsMode();
            // create players data set
            SmashUp.Players = new Dictionary<string, List<string>>();
            for (int i = 0; i < players; i++)
            {
                SmashUp.Players.Add("Player " + (i + 1).ToString(), new List<string>());
            }
            // initiate the selection mode
            beginSelection();
        }
        #endregion

        Random random;

        #region Selection Mode
        /// <summary>
        /// Method that starts the selection process
        /// </summary>
        private void beginSelection()
        {
            // display the controls for the selection mode
            displaySelectionMode();

            // we'll need to display the player and pool data, which is done with a tree view
            tvPlayers.BeginUpdate();
            foreach (var kvp in SmashUp.Players)
            {
                tvPlayers.Nodes.Add(kvp.Key, kvp.Key);
            }
            // Now we need to add the Pool Node
            tvPlayers.Nodes.Add("Faction Pool", "Faction Pool");
            foreach (string faction in SmashUp.Pool)
            {
                tvPlayers.Nodes["Faction Pool"].Nodes.Add(faction, faction);
            }
            tvPlayers.EndUpdate();
            tvPlayers.ExpandAll();
            // So at this point, we have the tree in place, so we need to start processing the modes
            SmashUp.iMode = 0;
            SmashUp.Modes = SmashUp.GameModes[cbGameMode.SelectedIndex].Modes;
            processNextMode();
        }

        /// <summary>
        /// Method that displays the controls used by selection mode
        /// </summary>
        private void displaySelectionMode()
        {
            tvPlayers.Visible = true;
        }

        /// <summary>
        /// Method that hides the controls used by selection mode
        /// </summary>
        private void hideSelectionMode()
        {
            tvPlayers.Visible = false;
        }

        /// <summary>
        /// Method that processes the next mode, meaning it will check if the next mode is Allot, Draft, Swap or Drop, then act accordingly
        /// </summary>
        private void processNextMode()
        {
            // iMode keeps track of which mode the randomizer is currently at - if it is beyond the modes array, that means we've finished
            if (SmashUp.iMode >= SmashUp.Modes.Length)
            {
                btnReturn.Visible = true;
                return;
            }
            // Check what the mode is, and act accordingly
            switch (SmashUp.Modes[SmashUp.iMode])
            {
                // If the next mode is Allot, the randomizer should do all allots at once and randomize a number of factions to each player
                case "Allot":
                    // we want to do all the consecutive Allots at once
                    int num = 1;
                    while (SmashUp.iMode < SmashUp.Modes.Length - 1 && SmashUp.Modes[SmashUp.iMode + 1] == "Allot")
                    {
                        SmashUp.iMode++;
                        num++;
                    }
                    AllotFactions(num);
                    // Once we've updated the player data and also the tree view, we proceed to the next mode
                    SmashUp.iMode++;
                    processNextMode();
                    break;
                    // If the next mode is Draft, we need to display and update the draft controls - Draft is driven by user input
                case "Draft":
                    displayDraftControls();
                    updateDraftControls();
                    break;
                    // If the next mode is Swap, we need to display and update the swap controls - Swap is driven by user input
                case "Swap":
                    displaySwapControls();
                    updateSwapControls();
                    break;
                    // If the next mode is Drop, we need to display and update the drop controls - Drop is driven by user input
                case "Drop":
                    displayDropControls();
                    updateDropControls();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method that allot factions from the faction pool to each player
        /// </summary>
        /// <param name="num">The number of factions alloted to each player from the pool</param>
        private void AllotFactions(int num)
        {
            tvPlayers.BeginUpdate();
            for (int i = 0; i < num; i++)
            {
                foreach (var kvp in SmashUp.Players)
                {
                    int iPool = random.Next(0, SmashUp.Pool.Count);
                    // Add the faction to the player data and the treeview
                    kvp.Value.Add(SmashUp.Pool[iPool]);
                    tvPlayers.Nodes[kvp.Key].Nodes.Add(SmashUp.Pool[iPool], SmashUp.Pool[iPool]);
                    // Remove the faction from the Pool
                    tvPlayers.Nodes["Faction Pool"].Nodes[SmashUp.Pool[iPool]].Remove();
                    SmashUp.Pool.RemoveAt(iPool);

                }
            }
            tvPlayers.EndUpdate();
            tvPlayers.ExpandAll();
        }

        /// <summary>
        /// Method that displays the draft controls
        /// </summary>
        private void displayDraftControls()
        {
            tbSelectionNote.Visible = true;
            tbFactionPool.Visible = true;
            cbFactionPool.Visible = true;
            btnDraft.Visible = true;
            btnRandom.Visible = true;
        }

        /// <summary>
        /// Method that hides the draft controls
        /// </summary>
        private void hideDraftControls()
        {
            tbSelectionNote.Visible = false;
            tbFactionPool.Visible = false;
            cbFactionPool.Visible = false;
            btnDraft.Visible = false;
            btnRandom.Visible = false;
        }

        /// <summary>
        /// Method that updates the draft controls - this is necessary as the controls should change as we go through the players
        /// </summary>
        private void updateDraftControls()
        {
            tbSelectionNote.Text = "Player " + (SmashUp.iPlayers + 1).ToString() + "'s turn to draft a faction";
            // Clear the combo box and re-add the factions
            // It would likely be more efficient to do remove the faction from the Items list one by one, but the performance hit isn't really noticable
            cbFactionPool.Items.Clear();
            foreach (string faction in SmashUp.Pool)
            {
                cbFactionPool.Items.Add(faction);
            }
            cbFactionPool.SelectedIndex = 0;
        }

        /// <summary>
        /// Event method triggered when the user clicks the Draft button.
        /// The faction pool combo-box should always have a value, so this method would draft the selected faction to the current player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDraft_Click(object sender, EventArgs e)
        {
            // Update the Players and Pool datasets and also the treeview
            string selection = cbFactionPool.SelectedItem.ToString();
            tvPlayers.BeginUpdate();
            SmashUp.Pool.Remove(selection);
            tvPlayers.Nodes["Faction Pool"].Nodes[selection].Remove();
            SmashUp.Players["Player " + (SmashUp.iPlayers + 1).ToString()].Add(selection);
            tvPlayers.Nodes["Player " + (SmashUp.iPlayers + 1).ToString()].Nodes.Add(selection, selection);
            tvPlayers.EndUpdate();
            tvPlayers.ExpandAll();

            // Once the controls are updated, we'll need to make a decision based on which player we're at
            // The draft order should be reversed whenever we reach the last player.
            // So for example, if the first draft goes from players 1 to 3, the next draft should go from players 3 to 1
            // This is accomplished by maintaining a flag called DraftReversed - whenever we reach the end of a draft round, we change it's value
            // So we need to check if we're at the last player of the draft round, based on iPlayers and DraftReversed
            if ((SmashUp.DraftReversed && SmashUp.iPlayers == 0) || (!SmashUp.DraftReversed && SmashUp.iPlayers >= SmashUp.Players.Count - 1))
            {
                SmashUp.DraftReversed = !SmashUp.DraftReversed;
                // Since we've reached the end of the draft round, proceed to the next node - note that it may not necessarily be another draft
                hideDraftControls();
                SmashUp.iMode++;
                processNextMode();
            }
            // Otherwise, we aren't at the end of a draft round, so we need to update iPlayers and the draft controls
            else
            {
                // If the draft isn't reversed iPlayers increases
                if (!SmashUp.DraftReversed)
                {
                    SmashUp.iPlayers++;
                }
                // If the draft is reversed, iPlayers decreases
                else
                {
                    SmashUp.iPlayers--;
                }
                // Update the draft controls, as we need to proceed to the next player
                updateDraftControls();
            }
        }

        /// <summary>
        /// Event method triggered when the user clicks the Random button.
        /// This method will randomly select a faction for the current player from the faction pool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandom_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            // Update the Players and Pool datasets and also the treeview
            string selection = cbFactionPool.Items[random.Next(0, cbFactionPool.Items.Count)].ToString();
            tvPlayers.BeginUpdate();
            SmashUp.Pool.Remove(selection);
            tvPlayers.Nodes["Faction Pool"].Nodes[selection].Remove();
            SmashUp.Players["Player " + (SmashUp.iPlayers + 1).ToString()].Add(selection);
            tvPlayers.Nodes["Player " + (SmashUp.iPlayers + 1).ToString()].Nodes.Add(selection, selection);
            tvPlayers.EndUpdate();
            tvPlayers.ExpandAll();

            // Once the controls are updated, we'll need to make a decision based on which player we're at
            // The draft order should be reversed whenever we reach the last player.
            // So for example, if the first draft goes from players 1 to 3, the next draft should go from players 3 to 1
            // This is accomplished by maintaining a flag called DraftReversed - whenever we reach the end of a draft round, we change it's value
            // So we need to check if we're at the last player of the draft round, based on iPlayers and DraftReversed
            if ((SmashUp.DraftReversed && SmashUp.iPlayers == 0) || (!SmashUp.DraftReversed && SmashUp.iPlayers >= SmashUp.Players.Count - 1))
            {
                SmashUp.DraftReversed = !SmashUp.DraftReversed;
                // Since we've reached the end of the draft round, proceed to the next node - note that it may not necessarily be another draft
                hideDraftControls();
                SmashUp.iMode++;
                processNextMode();
            }
            // Otherwise, we aren't at the end of a draft round, so we need to update iPlayers and the draft controls
            else
            {
                // If the draft isn't reversed iPlayers increases
                if (!SmashUp.DraftReversed)
                {
                    SmashUp.iPlayers++;
                }
                // If the draft is reversed, iPlayers decreases
                else
                {
                    SmashUp.iPlayers--;
                }
                // Update the draft controls, as we need to proceed to the next player
                updateDraftControls();
            }
        }

        /// <summary>
        /// Method that displays the swap controls
        /// </summary>
        private void displaySwapControls()
        {
            tbSelectionNote.Visible = true;
            tbFactionPool.Visible = true;
            cbFactionPool.Visible = true;
            tbSwap.Visible = true;
            cbSwap.Visible = true;
            btnSwap.Visible = true;
            btnPass.Visible = true;
        }

        /// <summary>
        /// Method that hides the swap controls
        /// </summary>
        private void hideSwapControls()
        {
            tbSelectionNote.Visible = false;
            tbFactionPool.Visible = false;
            cbFactionPool.Visible = false;
            tbSwap.Visible = false;
            cbSwap.Visible = false;
            btnSwap.Visible = false;
            btnPass.Visible = false;
        }

        /// <summary>
        /// Method that updates the swap controls - this is necessary as the controls should change as we go through the players
        /// </summary>
        private void updateSwapControls()
        {
            tbSelectionNote.Text = "Player " + (SmashUp.iPlayers + 1).ToString() + "'s turn to swap a faction";
            // Clear the pool combo box and re-add the factions
            // It would likely be more efficient to do remove the faction from the Items list one by one, but the performance hit isn't really noticable
            cbFactionPool.Items.Clear();
            foreach (string faction in SmashUp.Pool)
            {
                cbFactionPool.Items.Add(faction);
            }
            cbFactionPool.SelectedIndex = 0;
            // Clear the swap combox box and re-add the factions - this is required as the player should be different
            cbSwap.Items.Clear();
            foreach (string faction in SmashUp.Players["Player " + (SmashUp.iPlayers + 1).ToString()])
            {
                cbSwap.Items.Add(faction);
            }
            cbSwap.SelectedIndex = 0;
        }

        /// <summary>
        /// Event method triggered when the user clicks the Swap button.
        /// This method swaps a faction from the pool with one of the players factions, as selected from the swap controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwap_Click(object sender, EventArgs e)
        {
            string selection = cbFactionPool.SelectedItem.ToString();
            string swap = cbSwap.SelectedItem.ToString();
            string playerkey = "Player " + (SmashUp.iPlayers + 1).ToString();
            tvPlayers.BeginUpdate();
            // First, remove the selection from the pool
            SmashUp.Pool.Remove(selection);
            tvPlayers.Nodes["Faction Pool"].Nodes[selection].Remove();
            // Add the selection to the player
            SmashUp.Players[playerkey].Add(selection);
            tvPlayers.Nodes[playerkey].Nodes.Add(selection, selection);
            // Next, add the swap to the pool
            SmashUp.Pool.Add(swap);
            tvPlayers.Nodes["Faction Pool"].Nodes.Add(swap, swap);
            // Remove the swap from the player
            SmashUp.Players[playerkey].Remove(swap);
            tvPlayers.Nodes[playerkey].Nodes[swap].Remove();
            tvPlayers.EndUpdate();
            tvPlayers.ExpandAll();

            // For now, we'll assume that swaps always start from Player 1 and iPlayers increases
            // It probably should actually reverse order like the drafts do, but we should consider the funtionality
            // Should Draft, Swap & Drop all share one flag or separate flags? This is actually a serious consideration
            if (SmashUp.iPlayers >= SmashUp.Players.Count - 1)
            {
                hideSwapControls();
                SmashUp.iMode++;
                SmashUp.iPlayers = 0;
                processNextMode();
            }
            else
            {
                SmashUp.iPlayers++;
                updateSwapControls();
            }
        }

        /// <summary>
        /// Event method triggered when the user clicks the Pass button.
        /// Passes instead of swaping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            // For now, we'll assume that swaps always start from Player 1 and iPlayers increases
            // It probably should actually reverse order like the drafts do, but we should consider the funtionality
            // Should Draft, Swap & Drop all share one flag or separate flags? This is actually a serious consideration
            if (SmashUp.iPlayers >= SmashUp.Players.Count - 1)
            {
                hideSwapControls();
                SmashUp.iMode++;
                SmashUp.iPlayers = 0;
                processNextMode();
            }
            else
            {
                SmashUp.iPlayers++;
                updateSwapControls();
            }
        }

        /// <summary>
        /// Method that displays the drop controls
        /// </summary>
        private void displayDropControls()
        {
            tbSelectionNote.Visible = true;
            cbDrop.Visible = true;
            btnDrop.Visible = true;
        }

        /// <summary>
        /// Method that hides the drop controls
        /// </summary>
        private void hideDropControls()
        {
            tbSelectionNote.Visible = false;
            cbDrop.Visible = false;
            btnDrop.Visible = false;
        }

        /// <summary>
        /// Method that updates the drop controls - this is necessary as the controls should change as we go through the players
        /// </summary>
        private void updateDropControls()
        {
            tbSelectionNote.Text = "Player " + (SmashUp.iPlayers + 1).ToString() + "'s turn to drop a faction";
            // Clear the swap combox box and re-add the factions - this is required as the player should be different
            cbDrop.Items.Clear();
            foreach (string faction in SmashUp.Players["Player " + (SmashUp.iPlayers + 1).ToString()])
            {
                cbDrop.Items.Add(faction);
            }
            cbDrop.SelectedIndex = 0;
        }

        /// <summary>
        /// Event method triggered when the user clicks the Drop button.
        /// This method drops one of the player's factions and adds it to the faction pool.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrop_Click(object sender, EventArgs e)
        {
            string selection = cbDrop.SelectedItem.ToString();
            string drop = cbDrop.SelectedItem.ToString();
            string playerkey = "Player " + (SmashUp.iPlayers + 1).ToString();
            tvPlayers.BeginUpdate();
            // First, add the selection to the pool
            SmashUp.Pool.Add(selection);
            tvPlayers.Nodes["Faction Pool"].Nodes.Add(selection, selection);
            // Remove the selection from the player
            SmashUp.Players[playerkey].Remove(selection);
            tvPlayers.Nodes[playerkey].Nodes[selection].Remove();
            tvPlayers.EndUpdate();
            tvPlayers.ExpandAll();

            // For now, we'll assume that swaps always start from Player 1 and iPlayers increases
            // It probably should actually reverse order like the drafts do, but we should consider the funtionality
            // Should Draft, Swap & Drop all share one flag or separate flags? This is actually a serious consideration
            if (SmashUp.iPlayers >= SmashUp.Players.Count - 1)
            {
                hideDropControls();
                SmashUp.iMode++;
                SmashUp.iPlayers = 0;
                processNextMode();
            }
            else
            {
                SmashUp.iPlayers++;
                updateDropControls();
            }
        }
        #endregion

        /// <summary>
        /// Event method for when the Return button is clicked. Returns to the Game Options mdoe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            hideSelectionMode();
            hideDraftControls();
            hideSwapControls();
            hideDropControls();
            btnReturn.Visible = false;
            displayGameOptionsMode();
            tvPlayers.Nodes.Clear();
        }
    }

    /// <summary>
    /// Singleton class containing all the data structures used by the radomizer
    /// </summary>
    public sealed class Singleton
    {
        // Singleton implementation using Lazy<T>
        private Singleton() { }
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        /// <summary>
        /// Public instance of the Singleton class
        /// </summary>
        public static Singleton Instance
        {
            get { return lazy.Value; }
        }

        /// <summary>
        /// Class used to keep track of the factions, with Name, Set, Enabled and Lock as key properties
        /// </summary>
        public class Faction
        {
            private string _Name;
            /// <summary>
            /// Name of the faction
            /// </summary>
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }

            private string _Set;
            /// <summary>
            /// Set in which the faction is from
            /// </summary>
            public string Set
            {
                get { return _Set; }
                set { _Set = value; }
            }

            private bool _Enabled;
            /// <summary>
            /// Flag for if the faction is enabled for the radomizer
            /// </summary>
            public bool Enabled
            {
                get { return _Enabled; }
                set { _Enabled = value; }
            }

            private bool _Lock;
            /// <summary>
            /// Flag for if the faction is a lock for the radomizer
            /// </summary>
            public bool Lock
            {
                get { return _Lock; }
                set { _Lock = value; }
            }

            public Faction() { }

            /// <summary>
            /// Creates a Faction with name and set. Enabled and Lock are automatically true and false respectively
            /// </summary>
            /// <param name="name">Name of the faction</param>
            /// <param name="set">Set in which the faction if from</param>
            public Faction(string name, string set)
            {
                Name = name;
                Set = set;
                Enabled = true;
                Lock = false;
            }

        }

        /// <summary>
        /// Class to keep track of Set data, with Name and Enabled being the key properties
        /// </summary>
        public class Set
        {
            private string _Name;
            /// <summary>
            /// Name of the Set
            /// </summary>
            public string Name
            {
                get { return _Name; }
                set { _Name = value; } 
            }

            private bool _Enabled;
            /// <summary>
            /// Flag for if the set is enabled for the radomizer
            /// </summary>
            public bool Enabled
            {
                get { return _Enabled; }
                set { _Enabled = value; }
            }

            public Set() { }

            /// <summary>
            /// Creates a Set with name
            /// </summary>
            /// <param name="name">Name of the Set</param>
            public Set(string name)
            {
                Name = name;
                Enabled = true;
            }
        }

        private List<Faction> _Factions;
        /// <summary>
        /// List of all the factions available for Smash Up
        /// </summary>
        public List<Faction> Factions
        {
            get { return _Factions; }
            set { _Factions = value; }
        }

        private List<Set> _Sets;
        /// <summary>
        /// List of all the sets available for Smash Up
        /// </summary>
        public List<Set> Sets
        {
            get { return _Sets; }
            set { _Sets = value; }
        }

        /// <summary>
        /// Class used to store game mode data, with Name, Description
        /// </summary>
        public class GameMode
        {
            /// <summary>
            /// Name of the game mode
            /// </summary>
            private string _Name;
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }

            /// <summary>
            /// Description of the game mode, detailing how factions are randomized
            /// </summary>
            private string _Description;
            public string Description
            {
                get { return _Description; }
                set { _Description = value; }
            }

            /// <summary>
            /// Number of factions needed for the faction pool used by the randomizer
            /// </summary>
            private int _PoolSizePerPlayer;
            public int PoolSizePerPlayer
            {
                get { return _PoolSizePerPlayer; }
                set { _PoolSizePerPlayer = value; }
            }

            /// <summary>
            /// The sequence in which the factions are randomized - the four modes are Allot, Draft, Swap and Pool
            /// Allot : each player recieves a random faction from the pool
            /// Draft : each player selects one faction from the pool
            /// Swap : each player swaps one of their factions with one from the pool
            /// Drop : each player selects one of their factions and adds it to the pool
            /// </summary>
            private string[] _Modes;
            public string[] Modes
            {
                get { return _Modes; }
                set { _Modes = value; }
            }

            public GameMode() { }

            /// <summary>
            /// Create a game mode
            /// </summary>
            /// <param name="name">Name of the game mode</param>
            /// <param name="poolsizeperplayer">Number of factions needed for the faction pool used by the randomizer</param>
            public GameMode(string name, int poolsizeperplayer)
            {
                Name = name;
                PoolSizePerPlayer = poolsizeperplayer;
            }

            /// <summary>
            /// Add the game mode description
            /// </summary>
            /// <param name="description">Description of the game mode, detailing how factions are randomized</param>
            public void AddDescription(string description)
            {
                Description = description;
            }

            /// <summary>
            /// Add the sequence in which the factions are randomized
            /// </summary>
            /// <param name="modes">The four modes are Allot, Draft, Swap and Pool</param>
            public void AddModes(string[] modes)
            {
                Modes = modes;
            }
        }

        private List<GameMode> _GameModes;
        /// <summary>
        /// List of all the game modes this program supports
        /// </summary>
        public List<GameMode> GameModes
        {
            get { return _GameModes; }
            set { _GameModes = value; }
        }

        /// <summary>
        /// Method to be called right after the Singleton instance is created - this method should be called only once
        /// Adds all the factions, sets, and game modes data
        /// </summary>
        public void Initialize()
        {
            // First add all the factions with their corresponding set
            Factions = new List<Faction>();
            Factions.Add(new Faction("Aliens", "Base"));
            Factions.Add(new Faction("Dinosaurs", "Base"));
            Factions.Add(new Faction("Ninjas", "Base"));
            Factions.Add(new Faction("Pirates", "Base"));
            Factions.Add(new Faction("Robots", "Base"));
            Factions.Add(new Faction("Tricksters", "Base"));
            Factions.Add(new Faction("Wizards", "Base"));
            Factions.Add(new Faction("Zombies", "Base"));

            Factions.Add(new Faction("Bear Cavalry", "Awesome Level 9000"));
            Factions.Add(new Faction("Ghosts", "Awesome Level 9000"));
            Factions.Add(new Faction("Killer Plants", "Awesome Level 9000"));
            Factions.Add(new Faction("Steampunks", "Awesome Level 9000"));

            Factions.Add(new Faction("Minions of Cthulhu", "The Obligatory Cthulhu Set"));
            Factions.Add(new Faction("Elder Things", "The Obligatory Cthulhu Set"));
            Factions.Add(new Faction("Innsmouth", "The Obligatory Cthulhu Set"));
            Factions.Add(new Faction("Miskatonic University", "The Obligatory Cthulhu Set"));

            Factions.Add(new Faction("Cyborg Apes", "Science Fiction Double Feature"));
            Factions.Add(new Faction("Shapeshifters", "Science Fiction Double Feature"));
            Factions.Add(new Faction("Super Spies", "Science Fiction Double Feature"));
            Factions.Add(new Faction("Time Travelers", "Science Fiction Double Feature"));

            Factions.Add(new Faction("Giant Ants", "Monster Smash"));
            Factions.Add(new Faction("Mad Scientists", "Monster Smash"));
            Factions.Add(new Faction("Vampires", "Monster Smash"));
            Factions.Add(new Faction("Werewolves", "Monster Smash"));

            Factions.Add(new Faction("Fairies", "Pretty Pretty"));
            Factions.Add(new Faction("Mythic Horses", "Pretty Pretty"));
            Factions.Add(new Faction("Kitty Cats", "Pretty Pretty"));
            Factions.Add(new Faction("Princesses", "Pretty Pretty"));

            Factions.Add(new Faction("Clerics", "Munchkin"));
            Factions.Add(new Faction("Dwarves", "Munchkin"));
            Factions.Add(new Faction("Elves", "Munchkin"));
            Factions.Add(new Faction("Halflings", "Munchkin"));
            Factions.Add(new Faction("Mages", "Munchkin"));
            Factions.Add(new Faction("Orcs", "Munchkin"));
            Factions.Add(new Faction("Thieves", "Munchkin"));
            Factions.Add(new Faction("Warriors", "Munchkin"));

            Factions.Add(new Faction("Dragons", "It's Your Fault"));
            Factions.Add(new Faction("Mythic Greeks", "It's Your Fault"));
            Factions.Add(new Faction("Sharks", "It's Your Fault"));
            Factions.Add(new Faction("Superheroes", "It's Your Fault"));
            Factions.Add(new Faction("Tornados", "It's Your Fault"));

            Factions.Add(new Faction("Astroknights", "Cease & Desist"));
            Factions.Add(new Faction("Changerbots", "Cease & Desist"));
            Factions.Add(new Faction("Ignobles", "Cease & Desist"));
            Factions.Add(new Faction("Star Roamers", "Cease & Desist"));

            Factions.Add(new Faction("Explorers", "What Were We Thinking"));
            Factions.Add(new Faction("Grannies", "What Were We Thinking"));
            Factions.Add(new Faction("Rock Stars", "What Were We Thinking"));
            Factions.Add(new Faction("Teddy Bears", "What Were We Thinking"));

            Factions.Add(new Faction("Mega Troopers", "Big In Japan"));
            Factions.Add(new Faction("Magical Girls", "Big In Japan"));
            Factions.Add(new Faction("Kaiju", "Big In Japan"));
            Factions.Add(new Faction("Itty Critters", "Big In Japan"));

            Factions.Add(new Faction("Disco Dancers", "That 70s Expansion"));
            Factions.Add(new Faction("Kung Fu Fighters", "That 70s Expansion"));
            Factions.Add(new Faction("Truckers", "That 70s Expansion"));
            Factions.Add(new Faction("Vigilantes", "That 70s Expansion"));

            Factions.Add(new Faction("Ancient Egyptians", "Oops You Did It Again"));
            Factions.Add(new Faction("Cowboys", "Oops You Did It Again"));
            Factions.Add(new Faction("Samurai", "Oops You Did It Again"));
            Factions.Add(new Faction("Vikings", "Oops You Did It Again"));

            Factions.Add(new Faction("Luchadors", "World Tour Part 1"));
            Factions.Add(new Faction("Mounties", "World Tour Part 1"));
            Factions.Add(new Faction("Musketeers", "World Tour Part 1"));
            Factions.Add(new Faction("Sumo Wrestlers", "World Tour Part 1"));

            Factions.Add(new Faction("Russian Fairy Tales", "World Tour Part 2"));
            Factions.Add(new Faction("Anasi Tales", "World Tour Part 2"));
            Factions.Add(new Faction("Grimms' Fairy Tales", "World Tour Part 2"));
            Factions.Add(new Faction("Anceint Incas", "World Tour Part 2"));
            Factions.Add(new Faction("Polynesian Voyagers", "World Tour Part 2"));

            Factions.Add(new Faction("Geeks", "Promos"));
            Factions.Add(new Faction("All-Stars", "Promos"));
            Factions.Add(new Faction("Sheep", "Promos"));
            Factions.Add(new Faction("Penguins", "Promos"));

            // Then add all the sets - we can simply use the set data already in Factions
            Sets = new List<Set>();
            foreach (Faction f in Factions)
            {
                if (!Sets.Exists(s => s.Name == f.Set))
                {
                    Sets.Add(new Set(f.Set));
                }
            }

            // Lastly, add the game modes. This initialization is more in-depth, as you need to understand how the modes will be used by the radomizer
            // Essentially, the modes tell the radomizer the sequence in which the players interact with the faction pool
            // Allot means the players randomly recieve a faction from the pool
            // Draft means the players select a faction from the pool
            // Swap means the players swap one of their factions with another from the pool
            // Drop means the players drop one of their factions, and it's added to the pool
            GameModes = new List<GameMode>();
            GameModes.Add(new GameMode("Regular", 2));
            GameModes[GameModes.Count - 1].AddDescription("Each player receives 2 random factions.");
            GameModes[GameModes.Count - 1].AddModes(new string[] { "Allot", "Allot" });
            GameModes.Add(new GameMode("Double Draft", 2));
            GameModes[GameModes.Count - 1].AddDescription("A pool of factions twice the player count is randomly created. Players draft first to last, then last to first.");
            GameModes[GameModes.Count - 1].AddModes(new string[] { "Draft", "Draft" });
            GameModes.Add(new GameMode("Triple Draft", 3));
            GameModes[GameModes.Count - 1].AddDescription("A pool of factions trice the player count is randomly created. Players draft first to last, then last to first.");
            GameModes[GameModes.Count - 1].AddModes(new string[] { "Draft", "Draft" });
            GameModes.Add(new GameMode("Quadruple Draft", 4));
            GameModes[GameModes.Count - 1].AddDescription("A pool of factions quardrouple the player count is randomly created. Players draft first to last, then last to first");
            GameModes[GameModes.Count - 1].AddModes(new string[] { "Draft", "Draft" });
            GameModes.Add(new GameMode("Regular Swap", 3));
            GameModes[GameModes.Count - 1].AddDescription("Each player receives 2 random factions. A pool of factions equal to the player count is randomly created. Players can swap one faction.");
            GameModes[GameModes.Count - 1].AddModes(new string[] { "Allot", "Allot", "Swap" });
            GameModes.Add(new GameMode("Select Swap", 3));
            GameModes[GameModes.Count - 1].AddDescription("Each player recives 3 random factions and select 2, with the third entering the pool. Players can swap one faction.");
            GameModes[GameModes.Count - 1].AddModes(new string[] { "Allot", "Allot", "Allot", "Drop", "Swap" });
        }

        private List<string> _Locks;
        /// <summary>
        /// List of faction names that are locks as chosen by user
        /// </summary>
        public List<string> Locks
        {
            get { return _Locks; }
            set { _Locks = value; }
        }

        private List<string> _Randoms;
        /// <summary>
        /// List of faction names that are available to be chosen for the faction pool and also are not locks, as specified by user
        /// </summary>
        public List<string> Randoms
        {
            get { return _Randoms; }
            set { _Randoms = value; }
        }

        private Dictionary<string, List<string>> _Players;
        /// <summary>
        /// Dataset of the player and a list of their faction names
        /// </summary>
        public Dictionary<string, List<string>> Players
        {
            get { return _Players; }
            set { _Players = value; }
        }

        /// <summary>
        /// List of faction names available to be alloted or drafted by players
        /// The pool contains all the locks, with the remaining amount filled by Randoms
        /// </summary>
        private List<string> _Pool;
        public List<string> Pool
        {
            get { return _Pool; }
            set { _Pool = value; }
        }

        private string[] _Modes;
        /// <summary>
        /// The modes needed for the faction radomization/selection
        /// </summary>
        public string[] Modes
        {
            get { return _Modes; }
            set { _Modes = value; }
        }

        private int _iMode;
        /// <summary>
        /// Index used to keep track of which mode is currently being processed
        /// </summary>
        public int iMode
        {
            get { return _iMode; }
            set { _iMode = value; }
        }

        private int _iPlayers;
        /// <summary>
        /// Index used to keep track of which player is currently being processed
        /// </summary>
        public int iPlayers
        {
            get { return _iPlayers; }
            set { _iPlayers = value; }
        }

        private bool _DraftReversed;
        /// <summary>
        /// Flag used to determine if the draft needs to be reversed or not
        /// </summary>
        public bool DraftReversed
        {
            get { return _DraftReversed; }
            set { _DraftReversed = value; }
        }
    }
}
