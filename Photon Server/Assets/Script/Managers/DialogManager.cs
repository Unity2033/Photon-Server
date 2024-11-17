using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] Transform parentTransform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0) return;

            // inputField�� �ִ� �ؽ�Ʈ�� �����ɴϴ�.
            string talk = PhotonNetwork.LocalPlayer.NickName + " : " + inputField.text;

            // RPC Targer.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk() �Լ��� �����϶�� ������ �����մϴ�.
            photonView.RPC("Talk", RpcTarget.All, talk);
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        // Prefab�� �ϳ� ������ ���� text ���� �����մϴ�.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));

        // prefab ������Ʈ�� Text ������Ʈ�� �����ؼ� text�� ���� �����մϴ�.
        talk.GetComponent<Text>().text = message;

        // ��ũ�� �� - content ������Ʈ�� �ڽ����� ����մϴ�.
        talk.transform.SetParent(parentTransform);

        // talk ������Ʈ�� UI ũ�⸦ �ʱ�ȭ�մϴ�.
        talk.GetComponent<RectTransform>().localScale = Vector3.one;

        // ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� �����մϴ�.
        inputField.ActivateInputField();

        Canvas.ForceUpdateCanvases();

        // ��ũ���� ��ġ�� �ʱ�ȭ�մϴ�.
        scrollRect.verticalNormalizedPosition = 0.0f;

        // inputField�� �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.
        inputField.text = "";
    }
}