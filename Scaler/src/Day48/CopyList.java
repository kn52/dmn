package Day48;

import java.util.HashMap;

import Day45.ListNode;

public class CopyList {

	public static void main(String[] args) {
		int[] array = new int[] {  1, 2, 3, 4, 5 };
		RandomListNode head = new RandomListNode(array[0]);
		RandomListNode temp = head;
		for (int i = 1; i < array.length; i++) {
			RandomListNode new_node = new RandomListNode(array[i]);
			temp.next = new_node;
			if (i == 1) { 
				head.next = temp;
			}
			temp = temp.next;
		}
		RandomListNode ans = copyRandomList(head);
		System.out.print(ans);
	}
	public static RandomListNode copyRandomList(RandomListNode head) {
        if(head == null){
            return null;
        }

        HashMap<RandomListNode, RandomListNode> map = new HashMap<RandomListNode, RandomListNode>();
        RandomListNode current = head;
        
        while(current != null){
            RandomListNode currentB = new RandomListNode(current.val);
            map.put(current, currentB);
            current = current.next;
        }
        
        current = head;
        while(current != null){
            RandomListNode currentB = map.get(current);
            if(current.next != null){
                currentB.next = map.get(current.next);
            }
            if(current.random != null){
                currentB.random = map.get(current.random);
            }
            current = current.next;
        }

        return map.get(head);
    }
	public static void printElement(RandomListNode head) {
		RandomListNode temp = head;
		while (temp != null) {
			System.out.print(temp.val);
			temp = temp.next;
		}
	}
}
