namespace ParsePerSecond.Utils
{
    public enum ChatTypes : ushort
    {

        Damage = 2729,
        Weaponskill = 2091,
        DebuffInflictBySelfToEnemy = 2735, //maybe debuff done by player
        DebuffRecoverBySelf = 10929,
        BuffSelfGain = 2222, //tested w/ true north
        BuffSelfLose = 2224,
        FriendLogin = 8774,
        AttackMiss = 2218,
        PetAttack = 16427,
        PetDamage = 17065,
        HealSelf = 2221,
        PartyInviteOther = 8249,
        PartyCompositionChange = 4153,
        CastSummonStart = 2219,
        CastStart = 2731,
        CastStartPartyMember = 2347,
        CastStartPartyMemberToEnemy = 4139,
        DebuffInflictToPartyMember = 4399,
        PhysDamage = 2857, //no idea what happened here
        CastAllyStart = 2603,
        HealAlly = 2605,
        HealPartyMember = 2349,
        BuffAllyGain = 2606,
        BuffAllyLose = 8752,
        BuffPartyMemberGain = 2350,
        BuffPartyMemberLose = 4400,
        DifferentBuffPartyMemberGain = 4398, //showed up w/ transcendent
        SkillAlly = 8235,
        DamageDoneByAlly = 9001,
        AlsoDamageDoneByAlly = 4777,
        PartyMemberKO = 4410,
        PartyMemberRez = 4154,
        UseItem = 2092,


        //CastCancel = 2091, uses same ID as weaponskills and cast finishing
    }
}