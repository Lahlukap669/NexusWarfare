using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Icu.Text.Transliterator;
using Nexus_Warfare.Source.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input.Touch;

namespace Nexus_Warfare.Source.Controller
{

    public class TurretManager
    {
        public List<Turret> turrets { get; set; }
        private List<AnchorPoint> anchorPoints;
        private ContentManager contentManager;
        private Texture2D[] LevelTextures { get; set; }
        private String gun0Texture;
        private Turret selectedTurret;

        public TurretManager(ContentManager content)
        {
            turrets = new List<Turret>();
            anchorPoints = new List<AnchorPoint>();
            InitializeAnchorPoints();
            contentManager = content;
            IntializeGunTextures(contentManager);
            gun0Texture = "Guns/Gun01/Idle/Gun01-Idle_0";
            LoadContent();
        }
        private void InitializeAnchorPoints()
        {
            // Define the anchor points here
            anchorPoints.Add(new AnchorPoint(new Vector2(175, 1400), true));
            anchorPoints.Add(new AnchorPoint(new Vector2(330, 1400), true));
            anchorPoints.Add(new AnchorPoint(new Vector2(475, 1400), true));
            anchorPoints.Add(new AnchorPoint(new Vector2(610, 1400), true));
            anchorPoints.Add(new AnchorPoint(new Vector2(755, 1400), true));
            anchorPoints.Add(new AnchorPoint(new Vector2(900, 1400), true));
            anchorPoints.Add(new AnchorPoint(new Vector2(175, 1620)));
            anchorPoints.Add(new AnchorPoint(new Vector2(330, 1620)));
            anchorPoints.Add(new AnchorPoint(new Vector2(475, 1620)));
            anchorPoints.Add(new AnchorPoint(new Vector2(610, 1620)));
            anchorPoints.Add(new AnchorPoint(new Vector2(755, 1620)));
            anchorPoints.Add(new AnchorPoint(new Vector2(900, 1620)));
            anchorPoints.Add(new AnchorPoint(new Vector2(175, 1750)));
            anchorPoints.Add(new AnchorPoint(new Vector2(330, 1750)));
            anchorPoints.Add(new AnchorPoint(new Vector2(475, 1750)));
            anchorPoints.Add(new AnchorPoint(new Vector2(610, 1750)));
            anchorPoints.Add(new AnchorPoint(new Vector2(755, 1750)));
            anchorPoints.Add(new AnchorPoint(new Vector2(900, 1750)));
        }
        private void IntializeGunTextures(ContentManager contentManager)
        {
            LevelTextures = new Texture2D[8];
            LevelTextures[0] = contentManager.Load<Texture2D>("Guns/Gun01/Idle/Gun01-Idle_0");
            LevelTextures[1] = contentManager.Load<Texture2D>("Guns/Gun02/Idle/Gun02-Idle_0");
            LevelTextures[2] = contentManager.Load<Texture2D>("Guns/Gun03/Idle/Gun03-Idle_0");
            LevelTextures[3] = contentManager.Load<Texture2D>("Guns/Gun04/Idle/Gun04-Idle_0");
            LevelTextures[4] = contentManager.Load<Texture2D>("Guns/Gun05/Idle/Gun05-Idle_0");
            LevelTextures[5] = contentManager.Load<Texture2D>("Guns/Gun06/Idle/Gun06-Idle_0");
            LevelTextures[6] = contentManager.Load<Texture2D>("Guns/Gun07/Idle/Gun07-Idle_0");
            LevelTextures[7] = contentManager.Load<Texture2D>("Guns/Gun08/Idle/Gun08-Idle_0");

        }

        private void LoadContent()
        {
            PlaceGunAtAvailableAnchor(anchorPoints);
        }
        public List<Turret> GetTurrets()
        {
            return turrets;
        }
        public void PlaceGunAtAvailableAnchor(List<AnchorPoint> anchors)
        {
            foreach (var anchor in anchors)
            {
                if (anchor.IsActive)
                {
                    turrets.Add(new Turret(contentManager, gun0Texture, anchor, LevelTextures)); 
                }
            }
            return;

        }
        public void HandleInput(TouchCollection touchCollection)
        {
            foreach (var touch in touchCollection)
            {
                switch (touch.State)
                {
                    case TouchLocationState.Pressed:
                        foreach (var turret in turrets)
                        {
                            if (turret.GetBoundingRectangle().Contains(touch.Position))
                            {
                                selectedTurret = turret;
                                selectedTurret.isActive = false;
                                break;
                            }
                        }
                        break;

                    case TouchLocationState.Moved:
                        if (selectedTurret != null)
                        {
                            selectedTurret.Position = touch.Position;
                        }
                        break;

                    case TouchLocationState.Released:
                        if (selectedTurret != null)
                        {
                            SnapTurretToAnchor(selectedTurret);
                            selectedTurret = null;
                        }
                        break;
                }
            }
        }
        public bool PlaceTurretOnBackline()
        {
            var backlineAnchors = anchorPoints.Where(anchor => anchor.Position.Y == 1750 || anchor.Position.Y == 1620).ToList();

            foreach (var anchor in backlineAnchors)
            {
                if (!anchor.IsOccupied)
                {
                    var newTurret = new Turret(contentManager, gun0Texture, anchor, LevelTextures);
                    turrets.Add(newTurret);
                    anchor.IsOccupied = true;
                    return true; // Turret successfully placed
                }
            }
            return false; // No free space on the backline
        }
        public bool CanPlaceTurretOnBackline()
        {
            var backlineAnchors = anchorPoints.Where(anchor => anchor.Position.Y == 1750 || anchor.Position.Y == 1620).ToList();

            foreach (var anchor in backlineAnchors)
            {
                if (!anchor.IsOccupied)
                {
                    return true; // Turret can be placed
                }
            }
            return false; // No free space on the backline
        }

        private void SnapTurretToAnchor(Turret turret)
        {
            AnchorPoint closestAnchor = null;
            float closestDistance = float.MaxValue;

            // Iterate over all anchor points to find the closest one
            foreach (var anchor in anchorPoints)
            {
                float distance = Vector2.Distance(turret.Position, anchor.Position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestAnchor = anchor;
                }
            }

            // Proceed only if a closest anchor has been found
            if (closestAnchor != null)
            {
                // Check if there is already a turret at the closest anchor
                Turret existingTurret = turrets.FirstOrDefault(t => t.CurrentAnchor == closestAnchor);
                // Check if the existing turret at the anchor has the same level as the new turret
                if (existingTurret != null)
                {
                    if (turret.CurrentAnchor == closestAnchor)
                    {
                        SnapBackToOriginalAnchor(turret);
                    }
                    else if (existingTurret.Level == turret.Level)
                    {
                        // If there is a turret of the same level, upgrade it and remove the new turret
                        existingTurret.Upgrade();
                        turret.CurrentAnchor.IsOccupied = false;
                        turrets.Remove(turret);
                    }
                    else
                    {
                        // If there is a turret of a different level, revert the new turret to its original position
                        if (turret.CurrentAnchor != null)
                        {
                            turret.Position = turret.CurrentAnchor.Position;
                            turret.isActive = turret.CurrentAnchor.IsActive;
                        }
                    }
                }
                else
                {
                    // If there's no turret at the anchor, place the new turret there
                    turret.Position = closestAnchor.Position;
                    turret.isActive = closestAnchor.IsActive;
                    closestAnchor.IsOccupied = true;
                    if (turret.CurrentAnchor != null)
                    {
                        turret.CurrentAnchor.IsOccupied = false;
                    }
                    turret.CurrentAnchor = closestAnchor;
                }
            }
        }

        //diff turret to anchor it stops the turret from fireing on the curr position
        private void SnapBackToOriginalAnchor(Turret turret)
        {
            if (turret.CurrentAnchor != null)
            {
                turret.Position = turret.CurrentAnchor.Position; // Move turret back to its original anchor's position
                turret.isActive = turret.CurrentAnchor.IsActive; // Set the current anchor back to the original anchor
            }
        }


        public void Update(GameTime gameTime)
        {
            foreach (var turret in turrets)
            {
                turret.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var turret in turrets)
            {
                turret.Draw(spriteBatch);
            }
            if (selectedTurret != null)
            {
                selectedTurret.Draw(spriteBatch);
            }
        }
    }
}
