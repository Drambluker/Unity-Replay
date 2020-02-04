using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReplayRecord : MonoBehaviour
{
    public ReplayController controller;
    public Animator animation_ = null;
    List<AnimationRecord> animationRecords;
    List<Frame> frames;

    // Start is called before the first frame update
    void Start()
    {
        frames = new List<Frame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ReplayController.Mode == ReplayController.Modes.RECORD)
        {
            animationRecords = new List<AnimationRecord>();

            if (animation_ != null)
            {
                foreach (AnimatorControllerParameter item in animation_.parameters)
                {
                    string name = item.name;

                    if (item.type == AnimatorControllerParameterType.Float)
                    {
                        animationRecords.Add(new AnimationRecord(name, animation_.GetFloat(name), item.type));
                    }
                    else if (item.type == AnimatorControllerParameterType.Int)
                    {
                        animationRecords.Add(new AnimationRecord(name, animation_.GetInteger(name), item.type));
                    }
                    else if (item.type == AnimatorControllerParameterType.Bool)
                    {
                        animationRecords.Add(new AnimationRecord(name, animation_.GetInteger(name), item.type));
                    }
                }
            }

            frames.Add(new Frame(gameObject, transform.position, transform.localScale, transform.rotation, animationRecords));
        }
    }

    private void OnApplicationQuit()
    {
        using (Stream stream = File.Open("test.bin", FileMode.Create))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, frames);
        }
    }
}
