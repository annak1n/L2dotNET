﻿using L2dotNET.model.player;
using L2dotNET.tables;

namespace L2dotNET.Network.serverpackets
{
    class NpcHtmlMessage : GameserverPacket
    {
        public string Htm;
        private readonly int _objId;
        private readonly int _itemId;

        public NpcHtmlMessage(L2Player player, string file, int objId)
        {
            Htm = HtmCache.Instance.GetHtmByFilepath(file);
            _objId = objId;
            _itemId = 0;
        }

        public NpcHtmlMessage(L2Player player, string file, int objId, int itemId)
        {
            Htm = HtmCache.Instance.GetHtmByFilepath(file);
            _objId = objId;
            _itemId = itemId;
        }

        public NpcHtmlMessage(L2Player player, string plain, int objId, bool isPlain)
        {
            Htm = $"<html><body>{plain}</body></html>";
            _objId = objId;
            _itemId = 0;
        }

        public override void Write()
        {
            WriteByte(0x0f);
            WriteInt(_objId);
            WriteString(Htm);
            WriteInt(_itemId);
        }

        public void Replace(string p, object t)
        {
            Htm = Htm.Replace(p, t.ToString());
        }
    }
}