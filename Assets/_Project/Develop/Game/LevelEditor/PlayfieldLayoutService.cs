using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelEditor
{
    public class PlayfieldLayoutService
    {
        private Dictionary<Vector2Int, PlayfieldCell> _tilesMap;

        public PlayfieldLayoutService()
        {

        }

        public void ScanTilemap(Tilemap tilemap)
        {
            _tilesMap = new();

            tilemap.CompressBounds();
            var bounds = tilemap.cellBounds;

            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {
                    var tilePos = new Vector3Int(x, y, 0);
                    var pos2D = new Vector2Int(x, y);

                    var tile = tilemap.GetTile<AlternatingTile>(tilePos);

                    if (tile != null)
                    {
                        GameObject tileObject = tilemap.GetInstantiatedObject(tilePos);
                        if (tileObject != null)
                        {
                            var cellView = tileObject.GetComponent<PlayfieldCellView>();
                            if (cellView != null)
                            {
                                _tilesMap[pos2D] = new PlayfieldCell(cellView);
                            }
                        }
                    }
                }
            }
        }
    }
}