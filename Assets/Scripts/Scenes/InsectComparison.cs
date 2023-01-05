using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu
{
    public class InsectComparison : MonoBehaviour
    {
        [SerializeField]
        private Animator leafAnim;

        public static Animator leafAnimStatic;

        [SerializeField]
        private List<GameObject> computerInsects, playerInsects;

        private List<List<VectorPos>> vectorPositionsOfComputerInsects;

        private List<List<VectorPos>> vectorPositionsOfPlayerInsects;

        public static int activeFightIndex = -1;

        public static List<FightInfo> fightInfos;

        [SerializeField]
        private AudioSource fernandoSO;

        public static bool isFernandoSoundPlayed;

        [Serializable]
        public class ReferenceInsect
        {
            public List<GameObject> Insects;
        }

        public List<ReferenceInsect> referenceInspectsComputer = new List<ReferenceInsect>();
        public List<ReferenceInsect> referenceInspectsPlayer = new List<ReferenceInsect>();

        private void Start()
        {
            if (isFernandoSoundPlayed)
            {
                isFernandoSoundPlayed = false;

                fernandoSO.Play();
            }

            fightInfos = new List<FightInfo>()
            {
                new FightInfo
                {
                    Type = "3-2",
                    Winner = 3
                },
                new FightInfo
                {
                    Type = "2-3",
                    Winner = 3
                },
                new FightInfo
                {
                    Type = "3-4",
                    Winner = 3
                },
                new FightInfo
                {
                    Type = "4-3",
                    Winner = 3
                },
                new FightInfo
                {
                    Type = "2-1",
                    Winner = 2
                },
                new FightInfo
                {
                    Type = "1-2",
                    Winner = 2
                },
                new FightInfo
                {
                    Type = "2-0",
                    Winner = 2
                },
                new FightInfo
                {
                    Type = "0-2",
                    Winner = 2
                },
                new FightInfo
                {
                    Type = "1-3",
                    Winner = 1
                },
                new FightInfo
                {
                    Type = "3-1",
                    Winner = 1
                },
                new FightInfo
                {
                    Type = "1-4",
                    Winner = 1
                },
                new FightInfo
                {
                    Type = "4-1",
                    Winner = 1
                },
                new FightInfo
                {
                    Type = "0-3",
                    Winner = 0
                },
                new FightInfo
                {
                    Type = "3-0",
                    Winner = 0
                },
                new FightInfo
                {
                    Type = "0-1",
                    Winner = 0
                },
                new FightInfo
                {
                    Type = "1-0",
                    Winner = 0
                },
                new FightInfo
                {
                    Type = "4-2",
                    Winner = 4
                },
                new FightInfo
                {
                    Type = "2-4",
                    Winner = 4
                },
                new FightInfo
                {
                    Type = "4-0",
                    Winner = 4
                },
                new FightInfo
                {
                    Type = "0-4",
                    Winner = 4
                }
            };

            leafAnimStatic = leafAnim;

            vectorPositionsOfComputerInsects = new List<List<VectorPos>>();

            for (int i = 0; i < referenceInspectsComputer.Count; i++)
            {
                List<VectorPos> tempList = new List<VectorPos>();

                for (int j = 0; j < referenceInspectsComputer[i].Insects.Count; j++)
                {
                    tempList.Add(new VectorPos { X = referenceInspectsComputer[i].Insects[j].transform.localPosition.x, Y = referenceInspectsComputer[i].Insects[j].transform.localPosition.y });
                }

                vectorPositionsOfComputerInsects.Add(tempList);
            }

            vectorPositionsOfPlayerInsects = new List<List<VectorPos>>();

            for (int i = 0; i < referenceInspectsPlayer.Count; i++)
            {
                List<VectorPos> tempList = new List<VectorPos>();

                for (int j = 0; j < referenceInspectsPlayer[i].Insects.Count; j++)
                {
                    tempList.Add(new VectorPos { X = referenceInspectsPlayer[i].Insects[j].transform.localPosition.x, Y = referenceInspectsPlayer[i].Insects[j].transform.localPosition.y });
                }

                vectorPositionsOfPlayerInsects.Add(tempList);
            }

            for (int i = 0; i < vectorPositionsOfComputerInsects.Count; i++)
            {
                var vectorPos = vectorPositionsOfComputerInsects[SeeingInsect.computerInsectOrderList[i]][i];

                computerInsects[SeeingInsect.computerInsectOrderList[i]].transform.localPosition = new Vector3(ConvertedX(vectorPos.X), ConvertedY(vectorPos.Y), computerInsects[SeeingInsect.computerInsectOrderList[i]].transform.localPosition.z);
            }

            for (int i = 0; i < vectorPositionsOfPlayerInsects.Count; i++)
            {
                var vectorPos = vectorPositionsOfPlayerInsects[ThrowingInsect.playerInsectOrderList[i]][i];

                playerInsects[ThrowingInsect.playerInsectOrderList[i]].transform.localPosition = new Vector3(ConvertedX(vectorPos.X), ConvertedY(vectorPos.Y), playerInsects[ThrowingInsect.playerInsectOrderList[i]].transform.localPosition.z);
            }

            PlayLeafAnim();
        }

        public static void PlayLeafAnim()
        {
            activeFightIndex++;

            InsectFight.computerInsectIndex = SeeingInsect.computerInsectOrderList[activeFightIndex];
            InsectFight.playerInsectIndex = ThrowingInsect.playerInsectOrderList[activeFightIndex];

            leafAnimStatic.Play("Leaf" + (activeFightIndex + 1));
        }

        private float ConvertedX(float x)
        {
            return (Screen.width * x) / 1920;
        }

        private float ConvertedY(float y)
        {
            return (Screen.height * y) / 1080;
        }
    }

    public struct VectorPos
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class FightInfo
    {
        public string Type { get; set; }
        public int Winner { get; set; }
    }
}