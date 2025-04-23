using CustomTiles;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace LevelEditor
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;

        private Dictionary<Vector2Int, Cell> tileDictionary = new Dictionary<Vector2Int, Cell>();

        private void Start()
        {
            ScanTilemap();
            LogDictionaryContents();
        }
        public void ScanTilemap()
        {
            _tilemap.CompressBounds(); // Обновляем границы тайлмапа
            BoundsInt bounds = _tilemap.cellBounds;

            Debug.Log($"{bounds.xMax - bounds.xMin} {bounds.yMax - bounds.yMin}");

            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {
                    Vector3Int tilePos = new Vector3Int(x, y, 0);
                    Vector2Int pos2D = new Vector2Int(x, y); // Удобнее работать с Vector2Int

                    // Получаем тайл
                    AlternatingTile tile = _tilemap.GetTile<AlternatingTile>(tilePos);

                    if (tile != null)
                    {
                        // Получаем GameObject тайла (если он есть)
                        GameObject tileObject = _tilemap.GetInstantiatedObject(tilePos);

                        Debug.Log(tileObject);

                        if (tileObject != null)
                        {
                            // Пытаемся получить компонент Cell
                            Cell cellComponent = tileObject.GetComponent<Cell>();

                            if (cellComponent != null)
                            {
                                tileDictionary[pos2D] = cellComponent; // Добавляем в словарь
                            }
                        }
                    }
                }
            }
        }

        private void LogDictionaryContents()
        {
            foreach (var pair in tileDictionary)
            {
                Debug.Log($"Тайл в позиции {pair.Key} имеет компонент Cell:");
            }
        }
    }
}