﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace Holdstock
{
    static class BlockTextures
    {
        public static Texture grassSolo;
        public static Texture grass;
        public static Texture grassTopLeft;
        public static Texture grassTopRight;
        public static Texture grassBottomLeft;
        public static Texture grassBottomRight;
        public static Texture grassBottomMid;
        public static Texture grassMiddle;
        public static Texture grassLeft;
        public static Texture grassRight;

        public static Texture ground;
        public static Texture ring;
        public static Texture box;
        public static Texture spikes;
        public static Texture rock;
        public static Texture house;
        public static Texture interrupteur;
        public static Texture interrupteurOn;
        public static Texture princess;
        public static Texture princessPrison;

        public static Texture ghost;
        public static Texture cloud;

        public static Texture manaPotion;
        public static Texture lifePotion;


        public static void  loadTextures()
        {
            grassSolo = new Texture("images/grassSolo.png");
            grass = new Texture("images/grass100x100.png");
            grassTopLeft = new Texture("images/grassTopLeft.png");
            grassTopRight = new Texture("images/grassTopRight.png");
            grassBottomLeft = new Texture("images/grassBottomLeft.png");
            grassBottomRight = new Texture("images/grassBottomRight.png");
            grassBottomMid = new Texture("images/grassBottomMid.png");
            grassMiddle = new Texture("images/grassMiddle.png");
            grassLeft = new Texture("images/grassLeft.png");
            grassRight = new Texture("images/grassRight.png");

            ground = new Texture("images/ground.png");
            ring = new Texture("images/coin_spritesheet.png");
            box = new Texture("images/box.png");
            spikes = new Texture("images/trapsnspikes100x100.png");
            rock = new Texture("images/rock.png");
            house = new Texture("images/House.png");
            interrupteur = new Texture("images/InterrupteurOff.png");
            interrupteurOn = new Texture("images/InterrupteurOn.png");
            princess = new Texture("images/princess.png");
            princessPrison = new Texture("images/princessPrison.png");
            ghost = new Texture("images/ghost.png");
            cloud = new Texture("images/cloud.png");

            manaPotion = new Texture("images/ManaPotion.png");
            lifePotion = new Texture("images/LifePotion.png");
        }
    }
}
