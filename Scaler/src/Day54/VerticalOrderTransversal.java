package Day54;

import java.util.*;

public class VerticalOrderTransversal {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public ArrayList<ArrayList<Integer>> verticalOrderTraversal(ViewTreeNode A) {
        Map<Integer, ArrayList<ViewTreeNode>> map = new TreeMap<>();

        LinkedList<Node> que = new LinkedList<>();
        que.add(new Node(A, 0));

        while (!que.isEmpty()) {
            Node pop = que.removeFirst();

            if (map.containsKey(pop.distance)) {
                ArrayList<ViewTreeNode> list = map.get(pop.distance);
                list.add(pop.node);
                map.put(pop.distance, list);
            } else {
                ArrayList<ViewTreeNode> list = new ArrayList<>();
                list.add(pop.node);
                map.put(pop.distance, list);
            }

            if (pop.node.left != null) {
                que.addLast(new Node(pop.node.left, pop.distance - 1));
            }

            if (pop.node.right != null) {
                que.addLast(new Node(pop.node.right, pop.distance + 1));
            }
        }

        ArrayList<ArrayList<Integer>> ans = new ArrayList<>();
        for (int key : map.keySet()) {
            ArrayList<Integer> nodeList = new ArrayList<>();
            for (ViewTreeNode node : map.get(key)) {
                nodeList.add(node.val);
            }
            ans.add(nodeList);
        }

        return ans;
    }

    class Node {
        ViewTreeNode node;
        int distance;

        public Node(ViewTreeNode node, int distance) {
            this.node = node;
            this.distance = distance;
        }
    }
}

