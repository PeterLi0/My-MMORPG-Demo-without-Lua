using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Loading : Singleton<Loading>, IScene
{
    private string _targetScene;

    public void Initialize()
    {
        WindowManager.instance.Open<LoadingWnd>().Initialize();
        TimerManager.instance.Invoke(0.5f, () =>
        {
            Finalise();
            SceneManager.LoadScene(_targetScene);
        });
    }

    public void Finalise()
    {
        WindowManager.instance.Close<LoadingWnd>();
    }

    public void LoadScene(string targetScene)
    {
        _targetScene = targetScene;

        SceneManager.LoadScene("Loading");
    }
}

//using System;
//using System.Collections;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class Loading : MonoBehaviour, IScene
//{
//    //public Slider progressSlider;//进度条  
//    //public Text ProgressSliderText;//进度条进度显示文字  
//    private int nowProcess;//当前加载进度  
//    private AsyncOperation async;
//    public void Initialize()
//    {
//        WindowManager.instance.Open<LoadingWnd>().Initialize();
//    }

//    public void Finalise()
//    {
//        WindowManager.instance.Close<LoadingWnd>();
//    }
//    void Update()
//    {
//        if (async == null)
//        {
//            return;
//        }

//        int toProcess;
//        // async.progress 你正在读取的场景的进度值  0---0.9      
//        // 如果当前的进度小于0.9，说明它还没有加载完成，就说明进度条还需要移动      
//        // 如果，场景的数据加载完毕，async.progress 的值就会等于0.9    
//        if (async.progress < 0.9f)
//        {
//            toProcess = (int)async.progress * 100;
//        }
//        else
//        {
//            toProcess = 100;
//        }
//        // 如果滑动条的当前进度，小于，当前加载场景的方法返回的进度     
//        if (nowProcess < toProcess)
//        {
//            nowProcess++;
//            WindowManager.instance.Get<LoadingWnd>().UpdateSlider(nowProcess);
//        }

//       // progressSlider.value = nowProcess / 100f;
//        //设置progressText进度显示  
//      //  ProgressSliderText.text = progressSlider.value * 100 + "%";
//        // 设置为true的时候，如果场景数据加载完毕，就可以自动跳转场景     
//        if (nowProcess == 100)
//        {
//            async.allowSceneActivation = true;
//        }
//    }
//    //异步加载scene  
//    IEnumerator LoadScene(string sceneName)
//    {
//        async = SceneManager.LoadSceneAsync(sceneName);
//        async.allowSceneActivation = false;
//        yield return async;
//    }
//    //外部调用的加载的方法  
//    public static void ShowProgressBar(string sceneName)
//    {
//       StartCoroutine("LoadScene", sceneName);
//    }    
//}