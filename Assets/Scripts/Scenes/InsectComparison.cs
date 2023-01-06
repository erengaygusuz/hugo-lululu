using FTRGames.HugoLuLuLu.Models;
using FTRGames.HugoLuLuLu.Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace FTRGames.HugoLuLuLu.Scenes
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

        public List<ReferenceInsect> referenceInsectsComputer = new List<ReferenceInsect>();
        public List<ReferenceInsect> referenceInsectsPlayer = new List<ReferenceInsect>();

        private void Start()
        {
            Initialization();

            PlayFernandosound();

            FillComputerPositionListWithReferenceValues();

            FillPlayerPositionListWithReferenceValues();

            SettingComputerInsectsGameObjectsPos();

            SettingPlayerInsectsGameObjectsPos();

            PlayLeafAnim();
        }

        private void Initialization()
        {
            FightInfoInit();
            LeafAnimInit();
            ComputerVectorPosInit();
            PlayerVectorPosInit();
        }

        private void FightInfoInit()
        {
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
        }

        private void LeafAnimInit()
        {
            leafAnimStatic = leafAnim;
        }

        private void ComputerVectorPosInit()
        {
            vectorPositionsOfComputerInsects = new List<List<VectorPos>>();
        }

        private void PlayerVectorPosInit()
        {
            vectorPositionsOfPlayerInsects = new List<List<VectorPos>>();
        }

        private void PlayFernandosound()
        {
            if (isFernandoSoundPlayed)
            {
                isFernandoSoundPlayed = false;

                fernandoSO.Play();
            }
        }

        private void FillComputerPositionListWithReferenceValues()
        {
            for (int i = 0; i < referenceInsectsComputer.Count; i++)
            {
                List<VectorPos> tempList = new List<VectorPos>();

                for (int j = 0; j < referenceInsectsComputer[i].Insects.Count; j++)
                {
                    tempList.Add(new VectorPos { X = referenceInsectsComputer[i].Insects[j].transform.localPosition.x, Y = referenceInsectsComputer[i].Insects[j].transform.localPosition.y });
                }

                vectorPositionsOfComputerInsects.Add(tempList);
            }
        }

        private void FillPlayerPositionListWithReferenceValues()
        {
            for (int i = 0; i < referenceInsectsPlayer.Count; i++)
            {
                List<VectorPos> tempList = new List<VectorPos>();

                for (int j = 0; j < referenceInsectsPlayer[i].Insects.Count; j++)
                {
                    tempList.Add(new VectorPos { X = referenceInsectsPlayer[i].Insects[j].transform.localPosition.x, Y = referenceInsectsPlayer[i].Insects[j].transform.localPosition.y });
                }

                vectorPositionsOfPlayerInsects.Add(tempList);
            }
        }

        private void SettingComputerInsectsGameObjectsPos()
        {
            for (int i = 0; i < vectorPositionsOfComputerInsects.Count; i++)
            {
                var vectorPos = vectorPositionsOfComputerInsects[SeeingInsect.computerInsectOrderList[i]][i];

                computerInsects[SeeingInsect.computerInsectOrderList[i]].transform.localPosition = new Vector3(PositionConverter.ConvertedX(vectorPos.X), PositionConverter.ConvertedY(vectorPos.Y), computerInsects[SeeingInsect.computerInsectOrderList[i]].transform.localPosition.z);
            }
        }

        private void SettingPlayerInsectsGameObjectsPos()
        {
            for (int i = 0; i < vectorPositionsOfPlayerInsects.Count; i++)
            {
                var vectorPos = vectorPositionsOfPlayerInsects[ThrowingInsect.playerInsectOrderList[i]][i];

                playerInsects[ThrowingInsect.playerInsectOrderList[i]].transform.localPosition = new Vector3(PositionConverter.ConvertedX(vectorPos.X), PositionConverter.ConvertedY(vectorPos.Y), playerInsects[ThrowingInsect.playerInsectOrderList[i]].transform.localPosition.z);
            }
        }

        public static void PlayLeafAnim()
        {
            activeFightIndex++;

            InsectFight.computerInsectIndex = SeeingInsect.computerInsectOrderList[activeFightIndex];
            InsectFight.playerInsectIndex = ThrowingInsect.playerInsectOrderList[activeFightIndex];

            leafAnimStatic.Play("Leaf" + (activeFightIndex + 1));
        }
    }
}