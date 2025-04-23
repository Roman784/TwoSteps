using LevelEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CustomTiles
{
    public class AlternatingTile : TileBase
    {
        [SerializeField] private Sprite[] _tiles;
        [SerializeField] private Cell _prefab;

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            tileData.gameObject = _prefab.gameObject;

            uint mask = (uint)(position.x + position.y);
            tileData.sprite = _tiles[mask % 2];
        }

#if UNITY_EDITOR
        [MenuItem("Assets/Create/2D/Tiles/AlternatingTile")]
        public static void CreateAlternatingTile()
        {

            string path = EditorUtility.SaveFilePanelInProject(
                "Alternating Tile",
                "New Alternating Tile",
                "Asset",
                "Please enter a name for the new alternating tile",
                "Assets");

            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<AlternatingTile>(), path);
        }
#endif
    }
}