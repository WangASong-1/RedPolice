using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏管理类. Battle场景的 Manager of Managers
/// 外观模式:为子系统中的一组接口提供一致的界面,以供上层(BattleState)调用
/// 通过单例模式提供便利的访问方式,并限制了实例化
/// 中介者模式：子系统之间不互相调用,而是通过GameFacade来间接调用其他系统的方法
/// </summary>
public class GameFacade
{
    private bool m_IsGameOver = false;
    private static GameFacade m_Instance;
    private static object m_LockObj = new object();
    public bool IsGameOver
    {
        get { return m_IsGameOver; }
        set { m_IsGameOver = value; }
    }
    private GameFacade() { }

    //懒汉式单例模式
    public static GameFacade Instance
    {
        get {
            if (m_Instance == null)
            {
                lock (m_LockObj)
                {
                    if (m_Instance == null)
                        m_Instance = new GameFacade();
                }
            }
            return m_Instance;
        }
    }

    private AchievementSystem m_AchievementSystem;
    private CampSystem m_CampSystem;
    private CharacterSystem m_CharactorSystem;
    private EnergySystem m_EnergySystem;
    private GameEventSystem m_GameEventSystem;
    private StageSystem m_StageSystem;
    private FileDataSystem m_FileDataSystem;

    private CampInfoUI m_CampInfoUI;
    private GamePauseUI m_GamePauseUI;
    private GameStateInfoUI m_GameStateInfoUI;
    private SoldierInfoUI m_SolderInfoUI;

    //最好先Awake, 再Init. Awake中初始化数据, Init中再new对象之类的
    //不然部分new对象比较分散的,就不好给System初始化进行排序,有耦合。比如EventSubject
    public void Init() {
        m_AchievementSystem = new AchievementSystem();
        m_CampSystem = new CampSystem();
        m_CharactorSystem = new CharacterSystem();
        m_EnergySystem = new EnergySystem();
        m_GameEventSystem = new GameEventSystem();
        m_StageSystem = new StageSystem();
        m_FileDataSystem = new FileDataSystem();


        m_CampInfoUI = new CampInfoUI();
        m_GamePauseUI = new GamePauseUI();
        m_GameStateInfoUI = new GameStateInfoUI();
        m_SolderInfoUI = new SoldierInfoUI();

        m_FileDataSystem.Init();
        m_AchievementSystem.Init();
        m_CampSystem.Init();
        m_CharactorSystem.Init();
        m_EnergySystem.Init();
        m_GameEventSystem.Init();
        m_StageSystem.Init();

        m_CampInfoUI.Init();
        m_GamePauseUI.Init();
        m_GameStateInfoUI.Init();
        m_SolderInfoUI.Init();
        LoadMemento();
    }

    public void Update() {
        m_AchievementSystem.Update();
        m_CampSystem.Update();
        m_CharactorSystem.Update();
        m_EnergySystem.Update();
        m_GameEventSystem.Update();
        m_StageSystem.Update();

        m_CampInfoUI.Update();
        m_GamePauseUI.Update();
        m_GameStateInfoUI.Update();
        m_SolderInfoUI.Update();

    }

    public void Release() {
        m_AchievementSystem.Release();
        m_CampSystem.Release();
        m_CharactorSystem.Release();
        m_EnergySystem.Release();
        m_GameEventSystem.Release();
        m_StageSystem.Release();

        m_CampInfoUI.Release();
        m_GamePauseUI.Release();
        m_GameStateInfoUI.Release();
        m_SolderInfoUI.Release();

        CreateMemento();
    }

    public Vector3 GetEnemyTargetPosition()
    {
        return m_StageSystem.TargetPosition;
    }

    public void ShowCampInfo(ICamp camp)
    {
        m_CampInfoUI.ShowCampInfo(camp);
    }

    public void AddSoldier(ISoldier soldier)
    {
        m_CharactorSystem.AddSoldier(soldier);
    }

    public void AddEnemy(IEnemy enemy)
    {
        m_CharactorSystem.AddEnemy(enemy);
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        m_CharactorSystem.RemoveEnemy(enemy);
    }

    public bool TakeEnergy(int value)
    {
        return m_EnergySystem.TakeEnergy(value);
    }

    public void ShowMsg(string msg)
    {
        m_GameStateInfoUI.ShowMsg(msg);
    }

    public void RecycleEnergy(int value)
    {
        m_EnergySystem.RecycleEnergy(value);
    }

    public void UpdateEnergySlider(int nowEnergy, int maxEnergy)
    {
        m_GameStateInfoUI.UpdateEnergySlider(nowEnergy, maxEnergy);
    }


    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        m_GameEventSystem.RegisterObserver(eventType, observer);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        m_GameEventSystem.RemoveObserver(eventType, observer);

    }

    /// <summary>
    /// 外观模式: 事件激活
    /// </summary>
    /// <param name="eventType"></param>
    public void NotyfySubject(GameEventType eventType)
    {
        m_GameEventSystem.NotyfySubject(eventType);

    }

    /// <summary>
    /// 游戏初始化完成,加载数据
    /// </summary>
    private void LoadMemento()
    {
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        m_AchievementSystem.SetMemento(memento);
    }

    /// <summary>
    /// 游戏结束保存数据
    /// </summary>
    private void CreateMemento()
    {
        AchievementMemento memento = m_AchievementSystem.CreateMemento();
        memento.SaveData();
    }

    /// <summary>
    /// 访问者模式
    /// </summary>
    /// <param name="visitor"></param>
    public void RunVisitor(ICharacterVisitor visitor)
    {
        m_CharactorSystem.RunVisitor(visitor);
    }

    public Dictionary<string, CharacterBaseAttrModel> characterBaseAttr1 {
        get { return m_FileDataSystem.BaseAttr; }
    }
}
