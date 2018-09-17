using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Triangleman : MonoBehaviour {

    SkinnedMeshRenderer Skin;
    public Transform[] Bones;

	// Use this for initialization
	void Awake () {
        Mesh m = new Mesh();

        m.vertices = new Vector3[]
        {
            //머리
            new Vector3(-1,1,0),
            new Vector3(1,1,0),
            new Vector3(0,-1,0),

            //몸
            new Vector3(-2,-1,0),
            new Vector3(2,-1,0),
            new Vector3(0,-4,0),
            
            //왼팔
            new Vector3(-4,-1,0),
            new Vector3(-2,-1,0),
            new Vector3(-3,-3,0),

            //오른판
            new Vector3(2,-1,0),
            new Vector3(4,-1,0),
            new Vector3(3,-3,0),

            //왼골반
            new Vector3(-2,-4,0),
            new Vector3(0,-4,0),
            new Vector3(-1,-5,0),

            //오른 골반
            new Vector3(0,-4,0),
            new Vector3(2,-4,0),
            new Vector3(1,-5,0),

            //왼발
            new Vector3(-1,-5,0),
            new Vector3(-0.5f,-8,0),
            new Vector3(-1.5f,-8,0),

            //오른발
            new Vector3(1,-5,0),
            new Vector3(1.5f,-8,0),
            new Vector3(0.5f,-8,0),

            //왼손
            new Vector3(-3,-3,0),
            new Vector3(-2.5f,-4,0),
            new Vector3(-3.5f,-4,0),

            //오른손
            new Vector3(3,-3,0),
            new Vector3(3.5f,-4,0),
            new Vector3(2.5f,-4,0)
        };

        m.triangles = new int[]
        {
            0,1,2,
            3,4,5,
            6,7,8,
            9,10,11,
            12,13,14,
            15,16,17,
            18,19,20,
            21,22,23,
            24,25,26,
            27,28,29
        };

        m.bindposes = new Matrix4x4[]   //내부적으로 행렬 등록
        {
            Bones[0].worldToLocalMatrix * transform.localToWorldMatrix,
            Bones[1].worldToLocalMatrix * transform.localToWorldMatrix,
            Bones[2].worldToLocalMatrix * transform.localToWorldMatrix,
            Bones[3].worldToLocalMatrix * transform.localToWorldMatrix,
            Bones[4].worldToLocalMatrix * transform.localToWorldMatrix,
            Bones[5].worldToLocalMatrix * transform.localToWorldMatrix,
            Bones[6].worldToLocalMatrix * transform.localToWorldMatrix,
            Bones[7].worldToLocalMatrix * transform.localToWorldMatrix,
            Bones[8].worldToLocalMatrix * transform.localToWorldMatrix,
            Bones[9].worldToLocalMatrix * transform.localToWorldMatrix
        };

        m.boneWeights = new BoneWeight[]    //가중치 // 삼각형 0 1, 2,의 위치 boneIndex
        {
            //머리
            new BoneWeight() { boneIndex0 = 0, weight0 = 1},
            new BoneWeight() { boneIndex0 = 0, weight0 = 1},
            new BoneWeight() { boneIndex0 = 0, weight0 = 1},

            //몸통
            new BoneWeight() { boneIndex0 = 9, weight0 = 1},
            new BoneWeight() { boneIndex0 = 9, weight0 = 1},
            new BoneWeight() { boneIndex0 = 9, weight0 = 1},

            //왼팔
            new BoneWeight() { boneIndex0 = 1, weight0 = 1},
            new BoneWeight() { boneIndex0 = 1, weight0 = 1},
            new BoneWeight() { boneIndex0 = 1, weight0 = 1},

            //오른팔
            new BoneWeight() { boneIndex0 = 3, weight0 = 1},
            new BoneWeight() { boneIndex0 = 3, weight0 = 1},
            new BoneWeight() { boneIndex0 = 3, weight0 = 1},

            //왼골반
            new BoneWeight() { boneIndex0 = 5, weight0 = 1},
            new BoneWeight() { boneIndex0 = 5, weight0 = 1},
            new BoneWeight() { boneIndex0 = 5, weight0 = 1},

            //오른골반
            new BoneWeight() { boneIndex0 = 7, weight0 = 1},
            new BoneWeight() { boneIndex0 = 7, weight0 = 1},
            new BoneWeight() { boneIndex0 = 7, weight0 = 1},

            //왼발
            new BoneWeight() { boneIndex0 = 6, weight0 = 1},
            new BoneWeight() { boneIndex0 = 6, weight0 = 1},
            new BoneWeight() { boneIndex0 = 6, weight0 = 1},

            //오른발
            new BoneWeight() { boneIndex0 = 8, weight0 = 1},
            new BoneWeight() { boneIndex0 = 8, weight0 = 1},
            new BoneWeight() { boneIndex0 = 8, weight0 = 1},

            //왼손
            new BoneWeight() { boneIndex0 = 2, weight0 = 1},
            new BoneWeight() { boneIndex0 = 2, weight0 = 1},
            new BoneWeight() { boneIndex0 = 2, weight0 = 1},

            //오른손
            new BoneWeight() { boneIndex0 = 4, weight0 = 1},
            new BoneWeight() { boneIndex0 = 4, weight0 = 1},
            new BoneWeight() { boneIndex0 = 4, weight0 = 1}
        };

        Skin = GetComponent<SkinnedMeshRenderer>();
        Skin.sharedMesh = m;
        Skin.bones = Bones;
        Skin.quality = SkinQuality.Bone1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
